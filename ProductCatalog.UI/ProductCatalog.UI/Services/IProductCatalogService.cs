using ProductCatalog.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.UI.Services
{
    public interface IProductCatalogService
    {
        Task<List<ProductGetResponseModel>> GetProducts();
        Task<T> GetProductDetail<T>(int productId);
        Task<ProductCreateResponseModel> CreateProduct(ProductCreateRequestModel productCreateRequestModel);
        Task UpdateProduct(ProductUpdateRequestModel productUpdateRequestModel);
        Task DeleteProduct(int productId);
    }
}
