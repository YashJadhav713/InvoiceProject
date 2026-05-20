using Microsoft.AspNetCore.Mvc;
using InvoiceProject.Models;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace InvoiceProject.Controllers
{
    public class ProductController : Controller
    {
        ApisContext db;
        public ProductController()
        {
            db = new ApisContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetProducts()
        {
            List<TblProduct> lst = new List<TblProduct>();
            foreach (TblProduct p in db.TblProducts.ToList())
            {
                TblProduct pr = new TblProduct()
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Gst = (float)p.Gst,
                    Rate = (float)p.Rate,
                    Stock = (int)p.Stock
                };
                lst.Add(pr);
            }
            return Json(lst);
        }
        [HttpPost]
        public string AddProduct([FromBody] TblProduct p)
        {
            TblProduct pr = new TblProduct()
            {
                ProductName = p.ProductName,
                Gst = (float)p.Gst,
                Rate = (float)p.Rate,
                Stock = (int)p.Stock
            };
            db.TblProducts.Add(pr);
            db.SaveChanges();
            return "Product added successfully";
        }
        [HttpGet]
        public JsonResult GetProduct(int id)
        {
            TblProduct p = db.TblProducts.Find(id);
            TblProduct pr = new TblProduct()
            {
                ProductId = p.ProductId,
                Gst = (float)p.Gst,
                Rate = (float)p.Rate,
                ProductName = p.ProductName,
                Stock = (int)p.Stock
            };
            return Json(pr);
        }
        [HttpPost]
        public string UpdateProduct([FromBody] TblProduct p)
        {
            TblProduct pr = new TblProduct()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Stock = p.Stock,
                Gst = (float)p.Gst,
                Rate = (float)p.Rate
            };
            db.TblProducts.Update(pr);
            db.SaveChanges();
            return "Product updated successfully";
        }
        [HttpPost]
        public string DeleteProduct(int id)
        {
            TblProduct p = db.TblProducts.Find(id);
            db.TblProducts.Remove(p);
            db.SaveChanges();
            return "Product deleted successfully";
        }
    }
}
