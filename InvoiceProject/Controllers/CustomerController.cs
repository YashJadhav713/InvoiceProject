using Microsoft.AspNetCore.Mvc;
using InvoiceProject.Models;


namespace InvoiceProject.Controllers
{
    public class CustomerController : Controller
    {
        ApisContext db;
        public CustomerController()
        {
            db = new ApisContext();
        }
        public IActionResult CustomerAdd()
        {
            ViewData["Customer"] = db.TblCustomers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CustomerAdd(Customer tc)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Customer"] = db.TblCustomers.ToList();
                return View();
            }
            else
            {
                TblCustomer c = new TblCustomer
                {
                    CustomerName = tc.CustomerName,
                    Email = tc.Email,
                    Mobile = tc.Mobile,
                    City = tc.City
                };
                db.TblCustomers.Add(c);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.cmsg = "Added Successfully";
                ViewData["Customer"] = db.TblCustomers.ToList();
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            TblCustomer tc = db.TblCustomers.Find(id);
            if (tc == null)
            {
                return NotFound();
            }
            return View(tc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TblCustomer tc)
        {
            if (ModelState.IsValid)
            {
                db.TblCustomers.Update(tc);
                db.SaveChanges();
                return RedirectToAction("CustomerAdd");
            }

            return View(tc);
        }

        public IActionResult Delete(int id)
        {
            TblCustomer tc = db.TblCustomers.Find(id);
            if (true)
            {
                db.TblCustomers.Remove(tc);
                db.SaveChanges();
                return RedirectToAction("CustomerAdd");
            }
            return NotFound();
        }
    }
}
