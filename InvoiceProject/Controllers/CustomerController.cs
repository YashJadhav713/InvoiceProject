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

        public IActionResult Index()
        {
            return View();
        }

        // GET ALL CUSTOMERS
        [HttpGet]
        public JsonResult GetCustomers()
        {
            List<TblCustomer> lst = new List<TblCustomer>();

            foreach (TblCustomer c in db.TblCustomers.ToList())
            {
                TblCustomer cu = new TblCustomer()
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Mobile = c.Mobile,
                    City = c.City,
                    Email = c.Email
                };

                lst.Add(cu);
            }

            return Json(lst);
        }

        // ADD CUSTOMER
        [HttpPost]
        public string AddCustomer([FromBody] TblCustomer c)
        {
            if (c == null)
            {
                return "Invalid Customer Data";
            }

            TblCustomer cu = new TblCustomer()
            {
                CustomerName = c.CustomerName,
                Mobile = c.Mobile,
                City = c.City,
                Email = c.Email
            };

            db.TblCustomers.Add(cu);

            db.SaveChanges();

            return "Customer Added Successfully";
        }

        // GET SINGLE CUSTOMER
        [HttpGet]
        public JsonResult GetCustomer(int id)
        {
            TblCustomer c = db.TblCustomers.Find(id);

            // NULL CHECK
            if (c == null)
            {
                return Json("Customer Not Found");
            }

            TblCustomer cu = new TblCustomer()
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                Mobile = c.Mobile,
                City = c.City,
                Email = c.Email
            };

            return Json(cu);
        }

        // UPDATE CUSTOMER
        [HttpPost]
        public string UpdateCustomer([FromBody] TblCustomer c)
        {
            TblCustomer cu = db.TblCustomers.Find(c.CustomerId);

            // NULL CHECK
            if (cu == null)
            {
                return "Customer Not Found";
            }

            cu.CustomerName = c.CustomerName;
            cu.Mobile = c.Mobile;
            cu.City = c.City;
            cu.Email = c.Email;

            db.SaveChanges();

            return "Customer Updated Successfully";
        }

        // DELETE CUSTOMER
        [HttpPost]
        public string DeleteCustomer(int id)
        {
            TblCustomer c = db.TblCustomers.Find(id);

            // NULL CHECK
            if (c == null)
            {
                return "Customer Not Found";
            }

            db.TblCustomers.Remove(c);

            db.SaveChanges();

            return "Customer Deleted Successfully";
        }
    }
}
