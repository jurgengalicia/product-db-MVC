using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<mvcProductModel> prodlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            prodlist = response.Content.ReadAsAsync<IEnumerable<mvcProductModel>>().Result;
            return View(prodlist);
        }

        public ActionResult view()
        {
            return view();
        }

        public ActionResult Add(int id = 0)
        {
            return View(new mvcProductModel());
        }

        public ActionResult Search(string titleLike)
        {
            ProductsEntities1 db = new ProductsEntities1();
            return View(db.Products.Where(x => x.Title.Contains(titleLike) || titleLike == null).ToList());
        }

        [HttpPost]
        public ActionResult Add(mvcProductModel prod)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", prod).Result;
            return RedirectToAction("Add");
        }

    }
}