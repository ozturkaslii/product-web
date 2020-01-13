using Newtonsoft.Json;
using ProductCatalog.UI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.UI.Services
{
    public class ProductCatalogService :IProductCatalogService
    {
        private const string Endpoint = "api/Products";

        private readonly HttpClient _httpClient;

        public ProductCatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get all products in database
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductGetResponseModel>> GetProducts()
        {
            var getProducts = await _httpClient.GetStringAsync(Endpoint);

            var response = JsonConvert.DeserializeObject<List<ProductGetResponseModel>>(getProducts);

            return response;
        }

        /// <summary>
        /// Get product by product Id. Returns response in any type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<T> GetProductDetail<T>(int productId)
        {
            var getProduct = await _httpClient.GetStringAsync($"{Endpoint}/{productId}");

            var response = JsonConvert.DeserializeObject<T>(getProduct);

            return response;
        }

        /// <summary>
        /// Add product to database
        /// </summary>
        /// <param name="productCreateRequestModel"></param>
        /// <returns></returns>
        public async Task<ProductCreateResponseModel> CreateProduct(ProductCreateRequestModel productCreateRequestModel)
        {
            var content = new StringContent(JsonConvert.SerializeObject(productCreateRequestModel), Encoding.UTF8, "application/json");
            var createResponse = await _httpClient.PostAsync(Endpoint, content);

            if (!createResponse.IsSuccessStatusCode)
                throw new Exception("Product couldn't be added.");
               
            var result = createResponse.Content.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<ProductCreateResponseModel>(result);

            return response;
        }

        /// <summary>
        /// Update product in database
        /// </summary>
        /// <param name="productUpdateRequestModel"></param>
        /// <returns></returns>
        public async Task UpdateProduct(ProductUpdateRequestModel productUpdateRequestModel)
        {
            var content = new StringContent(JsonConvert.SerializeObject(productUpdateRequestModel), Encoding.UTF8, "application/json");
            var updateResponse = await _httpClient.PutAsync($"{Endpoint}/{productUpdateRequestModel.Id}", content);

            if (!updateResponse.IsSuccessStatusCode)
                throw new Exception("Product couldn't be updated.");
        }

        /// <summary>
        /// Delete product from database
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
       public async Task DeleteProduct(int productId)
       {
           var deleteResponse = await _httpClient.DeleteAsync($"{Endpoint}/{productId}");
           if (!deleteResponse.IsSuccessStatusCode)
               throw new Exception("Product couldn't be deleted.");
        }
    }
}
