using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ShoppingList.Models;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                List<Product> products = db.Products.ToList();

                return View(products);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (product == null)
            {
                return RedirectToAction("Index");
            }
        
            // ????????????
            if (string.IsNullOrWhiteSpace(product.Name) || product.Priority == 0 ||
                string.IsNullOrWhiteSpace(product.Status) || product.Quantity == 0)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                using (var db = new ShoppingListDbContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new ShoppingListDbContext())
            {
                Product product = db.Products.Find(id);

                if (product == null)
                {
                    return HttpNotFound();
                }

                return View(product);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Product productModel)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(productModel);
                //return RedirectToAction("Edit", new { id = filmModel.Id });
                //return RedirectToAction("Index");
            }

            using (var db = new ShoppingListDbContext())
            {
                var productFromDb = db.Products.Find(productModel.Id);

                if (productFromDb == null)
                {
                    return HttpNotFound();
                }

                productFromDb.Priority = productModel.Priority;
                productFromDb.Name = productModel.Name;
                productFromDb.Quantity = productModel.Quantity;
                productFromDb.Status = productModel.Status;
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}