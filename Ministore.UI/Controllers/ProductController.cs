using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Ministore.BusinessLogic.Services.Interfaces;
using Ministore.CrossCuttingConcerns.DTOs;
using Ministore.UI.Attributes;
using Ministore.UI.Models;
using Ninject.Infrastructure.Language;
using WebGrease.Css.Extensions;
using Ministore.BusinessLogic.Services.Implementations.ProductService;
using Ministore.BusinessLogic.Services.Implementations;

namespace Ministore.UI.Controllers
{
  
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Shop()
        {
            var products = _productService.GetAll();
            var cart = System.Web.HttpContext.Current.Session["Cart"] as List<ProductViewModel>;
            
            var shopModel = new ShopViewModel
            {
                Products = MapListToProductViewModel(products).ToList()
            };
            if (cart != null)
            {
                shopModel.ProductsInShoppingCart = cart;
                var total = 0.00;
                cart.ForEach(product =>
                {
                    total += Convert.ToDouble(product.Price);
                });
                shopModel.TotalPrice = total.ToString("0.00", CultureInfo.InvariantCulture);
            }
            return View("Shop", shopModel);
        }

        [AuthAttribute]
        public ActionResult ListOfProducts()
        {
            var products = _productService.GetAll();
            return View("ListOfProducts", MapListToProductViewModel(products));
        }

        public ActionResult AddToShoppingCart(Guid id)
        {
            var product = _productService.GetProductById(id);
            var currentProductsInCart = (List<ProductViewModel>)Session["Cart"] ?? new List<ProductViewModel>();
            currentProductsInCart.Add(MapToProductViewModel(product));
            Session["Cart"] = currentProductsInCart;
            return RedirectToAction("Shop");
        }

        public ActionResult ClearSession()
        {
            Session["Cart"] = null;
            return RedirectToAction("Shop");
        }

        [AuthAttribute]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProductViewModel();
            return View("Create", model);
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            var newProduct = new ProductDto
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price
            };
            _productService.CreateProduct(newProduct);
            return RedirectToAction("ListOfProducts");
        }

        [AuthAttribute]
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var product = _productService.GetProductById(id);
            return View("Edit", MapToProductViewModel(product));
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            var newProduct = new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
            };
            _productService.EditProduct(newProduct);

            return RedirectToAction("ListOfProducts");
        }

        [AuthAttribute]
        public ActionResult Details(Guid id)
        {
            var product = _productService.GetProductById(id);
            return View("Details", MapToProductViewModel(product));
        }

        [AuthAttribute]
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var model = _productService.GetProductById(id);
            return View("Delete", MapToProductViewModel(model));
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult Delete(ProductViewModel model)
        {
            var deletedProduct = new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
            };
            _productService.DeleteProduct(deletedProduct);
            return RedirectToAction("ListOfProducts");
        }

        public IEnumerable<ProductViewModel> MapListToProductViewModel(IEnumerable<ProductDto> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            products.ForEach(product => productsViewModels.Add(new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            }));

            return productsViewModels.ToEnumerable();
        }

        public ProductViewModel MapToProductViewModel(ProductDto product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            var products = _productService.GetAll();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ExportJson(string products)
        {
            var factory = new FactoryExporter<JsonExporter>();
            var exporter = factory.CreateExporter();
            exporter.Export(products);
            return RedirectToAction("ListOfProducts");
        }

        [HttpPost]
        public ActionResult ExportCsv()
        {
            var allProducts = _productService.GetAll().ToList();
            var factory = new FactoryExporter<CsvExporter>();
            var exporter = factory.CreateExporter();
            exporter.Export(allProducts);
            return RedirectToAction("ListOfProducts");
        }
    }
}
