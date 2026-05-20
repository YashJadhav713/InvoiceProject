using Microsoft.AspNetCore.Mvc;
using InvoiceProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace day12_invoice_core_mvc.Controllers
{
    public class InvoiceController : Controller
    {
        ApisContext db;
        public InvoiceController()
        {
            db = new ApisContext();
        }
        public IActionResult Index()
        {
            ViewBag.products = new SelectList(db.TblProducts.ToList(), "ProductId", "ProductName");
            ViewBag.customers = new SelectList(db.TblCustomers.ToList(), "CustomerId", "CustomerName");

            return View();
        }
    }
}