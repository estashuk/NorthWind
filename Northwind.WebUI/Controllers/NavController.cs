using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;

namespace Northwind.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly ICategoryRepository _repository;

        public NavController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.Category = category;
            IEnumerable<string> categories = _repository.Categories.Where(x => x.CategoryName == "Confections" || x.CategoryName == "Beverages").Select(x => x.CategoryName).OrderBy(x => x);
            return PartialView(categories);
            //return "Hello from nav controller";
        }
    }
}