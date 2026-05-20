using System;
using System.Collections.Generic;
namespace InvoiceProject.Model
{
    public class TblProduct
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public double? Rate { get; set; }

        public double? Gst { get; set; }

        public int? Stock { get; set; }

        public virtual ICollection<TblinvoicePayment> TblinvoicePayments { get; set; } = new List<TblinvoicePayment>();

        public virtual ICollection<TblinvoiceProduct> TblinvoiceProducts { get; set; } = new List<TblinvoiceProduct>();

    }
}
