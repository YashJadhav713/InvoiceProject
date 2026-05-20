using InvoiceProject.Models;
using System;
using System.Collections.Generic;
namespace InvoiceProject.Model
{
    public class TblinvoicePayment
    {
        public int PaymentId { get; set; }

        public int? InvoiceId { get; set; }

        public int? ProductId { get; set; }

        public double? PaymentAmount { get; set; }

        public string? PaymentMode { get; set; }

        public string? PaymentDescription { get; set; }

        public virtual TblinvoiceDetail? Invoice { get; set; }

        public virtual TblProduct? Product { get; set; }

    }
}
