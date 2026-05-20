using System.ComponentModel.DataAnnotations;
namespace InvoiceProject.Models

{
    public class Customer
    {
        [Required(ErrorMessage = "Customer Name is required")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        public string? Mobile { get; set; }

        [Required(ErrorMessage ="City is required")]
        public string? City { get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string? Email { get; set; }
    }
}
