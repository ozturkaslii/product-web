using Microsoft.AspNetCore.Mvc;
using ProductCatalog.UI.Models;
using ProductCatalog.UI.Services;
using System.Threading.Tasks;

namespace ProductCatalog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductCatalogService _productCatalogService;

        public HomeController(IProductCatalogService productCatalogService)
        {
            _productCatalogService = productCatalogService;
        }

        [Route("")]
        [Route("/Home")]
        [Route("/Home/Index")]
        public async Task<IActionResult> Index()
        {
            var response = await _productCatalogService.GetProducts();

            return View(response);
        }

        [HttpGet("/Home/Details/{productId}")]
        public async Task<IActionResult> Details(int productId)
        {
            var response = await _productCatalogService.GetProductDetail<ProductGetResponseModel>(productId);
            if (response == null)
                return RedirectToAction("Index");

            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequestModel productCreateRequestModel)
        {
            await _productCatalogService.CreateProduct(productCreateRequestModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/Home/Edit/{productId}")]
        public async Task<IActionResult> Edit(int productId)
        {
            var response = await _productCatalogService.GetProductDetail<ProductUpdateRequestModel>(productId);
            if (response == null)
                return RedirectToAction("Index");

            return View(response);
        }

        [HttpPost]
        [Route("/Home/Edit/{productId}")]
        public async Task<IActionResult> Edit(ProductUpdateRequestModel productUpdateRequestModel)
        {
            await _productCatalogService.UpdateProduct(productUpdateRequestModel);

            return RedirectToAction("Index");
        }

        public async Task<RedirectToActionResult> Delete(int id)
        {
            await _productCatalogService.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}
