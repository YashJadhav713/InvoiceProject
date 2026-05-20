using System;
using System.Collections.Generic;
namespace InvoiceProject.Model
{
    public class TblInvoicedetail
    {
        public int InvoiceId { get; set; }

        public DateOnly? InvoiceDate { get; set; }

        public int? CustomerId { get; set; }

        public string? TotalAmount { get; set; }

        public virtual TblCustomer? Customer { get; set; }

        public virtual ICollection<TblinvoicePayment> TblinvoicePayments { get; set; } = new List<TblinvoicePayment>();

        public virtual ICollection<TblinvoiceProduct> TblinvoiceProducts { get; set; } = new List<TblinvoiceProduct>();

    }
}
