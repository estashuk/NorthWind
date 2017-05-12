using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;
using Domain.Entities;
using Northwind.WebUI.Models;

namespace Northwind.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public int pageSize = 15;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = _productRepository.Products
                    .Where(x => category == null || x.Categories.CategoryName == category)
                    .OrderBy(p => p.ProductName)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                        _productRepository.Products.Count() :
                        _productRepository.Products.Count(x => x.Categories.CategoryName == category)
                },
                CurrentCategory = category
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(x=> x.ProductID == productId);
            return product != null ? File(product.Categories.Picture, "image / jpg") : null;
        }
    }
}