using Product.Application.Domain.Models;

namespace Product.Application.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetList(int page, int quantity, string filter);
        Task<ProductModel> Get(long ProductId);
        Task<long> Insert(ProductModel obj);
        Task<bool> Update(ProductModel obj);
        Task<bool> Delete(long ProductId);
        Task<long> InsertProductImages(ProductImages obj);
        Task<IEnumerable<ProductImages>> GetListImages(long ProductId);
        Task DeleteImages(long ProductId);
    }
}
