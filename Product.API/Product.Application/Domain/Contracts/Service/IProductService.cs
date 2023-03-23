using Product.Application.Domain.Models;

namespace Product.Application.Domain.Contracts.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetList(int page, int quantity, string filter);
        Task<ProductModel> Get(long ProductId);
        Task<long> Insert(ProductModel obj);
        Task<bool> Update(long ProductId, ProductModel obj); 
        Task<bool> Delete(long ProductId);
    }
}
