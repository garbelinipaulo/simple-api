using Product.Application.Domain.Contracts.Repositories;
using Product.Application.Domain.Models;
using Product.Application.Infra.Repositories.Base;

namespace Product.Application.Infra.Repositories
{ 
    public class ProductRepository : IProductRepository
    {
        private readonly IBaseRepository _baseRepository;
        public ProductRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<ProductModel>> GetList(int page, int quantity, string filter)
        {
            string _where = string.Empty;

            if(!string.IsNullOrEmpty(filter)) 
                _where = $" WHERE p.ProductName like '%{filter}%' or p.ProductDescription like '%{filter}%' ";
           
          return await _baseRepository.DbQueryAsync<ProductModel>(ProductQuery.GetList(_where), new { page, quantity });
        }

        public async Task<ProductModel> Get(long ProductId) => await _baseRepository.DbQuerySingleAsync<ProductModel>(ProductQuery.Get, new { ProductId });

        public async Task<long> Insert(ProductModel obj) => await _baseRepository.DbQuerySingleAsync<long>(ProductQuery.Insert, _baseRepository.MappingParameters(obj)); 

        public async Task<bool> Update(ProductModel obj) => await _baseRepository.DbExecuteAsync(ProductQuery.Update, _baseRepository.MappingParameters(obj));
         
        public async Task<bool> Delete(long ProductId) => await _baseRepository.DbExecuteAsync(ProductQuery.Delete, new { ProductId });


        #region Images
         
        public async Task<long> InsertProductImages(ProductImages obj) => await _baseRepository.DbQuerySingleAsync<long>(ProductQuery.InsertImages, _baseRepository.MappingParameters(obj));

        public async Task<IEnumerable<ProductImages>> GetListImages(long ProductId) => await _baseRepository.DbQueryAsync<ProductImages>(ProductQuery.GetListImages, new { ProductId });

        public async Task DeleteImages(long ProductId) => await _baseRepository.DbExecuteAsync(ProductQuery.DeleteImages, new { ProductId });



        #endregion
    }
}
