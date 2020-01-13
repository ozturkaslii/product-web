using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalog.UI.Models;

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
