using Microsoft.Extensions.Logging;
using Product.Application.Domain.Contracts.Notification;
using Product.Application.Domain.Contracts.Repositories;
using Product.Application.Domain.Contracts.Service;
using Product.Application.Domain.Models;
using Product.Application.Service.Base;
using System.Net;

namespace Product.Application.Service
{
    /// <summary>
    /// This service is designed to insert a product register
    /// </summary>
    public class ProductService : BaseService<ProductService>, IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        /// <summary>
        /// Constructor and injections.
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="logger"></param>
        /// <param name="notify"></param>
        public ProductService(
                IFileService fileService,
                IProductRepository productRepository,
                ILogger<ProductService> logger,
                INotificator notify) : base(logger, notify)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }


        public async Task<IEnumerable<ProductModel>> GetList(int page, int quantity, string filter)
        {
            if (page == 0) page = 1;
            if (quantity <= 0 || quantity > 100) quantity = 100;

            IEnumerable<ProductModel> _return = await _productRepository.GetList(page, quantity, filter);

            if (_return == null)
                _notify.AddNotification("Something is wrong with the DB!", (int)HttpStatusCode.InternalServerError);

            if (!_notify.HasNotifications)
                _notify.AttributeStatusCode((int)HttpStatusCode.OK);

            return _return;
        }

        public async Task<ProductModel> Get(long ProductId)
        {
            if (ProductId <= 0)
                _notify.AddNotification("ProductId is necessary!", (int)HttpStatusCode.BadRequest);

            ProductModel _return = await _productRepository.Get(ProductId);

            if (_return == null)
            {
                _notify.AddNotification("ProductId was not found on db!", (int)HttpStatusCode.NotFound);
                _return = new ProductModel();
            }

            _return.ProductImages = (await _productRepository.GetListImages(ProductId)).ToList();

            _notify.AttributeStatusCode((int)HttpStatusCode.OK);

            return _return;
        }
        public async Task<long> Insert(ProductModel obj)
        {
            long _idReturn = 0;
            obj.CreatedDate = DateTime.Now;
            obj.UpdatedDate = DateTime.Now;

            if (obj.Price <= 0)
            {
                _notify.AddNotification("Price with 0 or bellow is not allowed!", (int)HttpStatusCode.BadRequest);
                return _idReturn;
            }


             _idReturn = await _productRepository.Insert(obj);

            if (_idReturn == 0)
                _notify.AddNotification("The product was not created, something wrong happened!", (int)HttpStatusCode.InternalServerError);
            else
                _notify.AttributeStatusCode((int)HttpStatusCode.Created);


            //process to insert images
            if (!_notify.HasNotifications && obj.ProductImages.Where(c => c.ImageBase64 != null).Any())
                await InsertProductImage(_idReturn, obj.ProductImages);


            return _idReturn;
        }

        public async Task<bool> Update(long ProductId, ProductModel obj)
        {
            await ProductExist(ProductId);

            if (_notify.HasNotifications)
                return false;

            obj.UpdatedDate = DateTime.Now;

            bool _return = await _productRepository.Update(obj);

            if (_return == false)
                _notify.AddNotification("Something is wrong with the DB!", (int)HttpStatusCode.InternalServerError);

            //process to insert images
            await InsertProductImage(ProductId, obj.ProductImages.Where(c => c.ImageBase64 != null));

            return _return;
        }

        public async Task<bool> Delete(long ProductId)
        {
            await ProductExist(ProductId);

            if(_notify.HasNotifications)
                return false;

             await _productRepository.DeleteImages(ProductId);

            bool _return = await _productRepository.Delete(ProductId);

            if (_return == false)
                _notify.AddNotification("Something is wrong with the DB!", (int)HttpStatusCode.InternalServerError);


            return _return;
        }


        /// <summary>
        /// Just add a notification to warn that product is not on db
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        private async Task ProductExist(long ProductId)
        {
            if (ProductId <= 0)
            {
                _notify.AddNotification("ProductId is necessary!", (int)HttpStatusCode.BadRequest);
                return;
            }

            ProductModel product = await Get(ProductId);

            if (product == null)
                _notify.AddNotification("ProductId was not found on db!", (int)HttpStatusCode.NotFound);
        }

        private async Task InsertProductImage(long ProductId, IEnumerable<ProductImages> ProductImages)
        {
            foreach (var item in ProductImages.Where(c => !string.IsNullOrEmpty(c.ImageBase64)))
            {
                string? _returnPath = await _fileService.UploadFileAsync(item.ImageBase64, new Guid().ToString());

                if (!string.IsNullOrEmpty(_returnPath))
                {
                    item.ProductId = ProductId;
                    item.ImageUrl = _returnPath;
                    await _productRepository.InsertProductImages(item);
                }
            }
        }

    }
}
