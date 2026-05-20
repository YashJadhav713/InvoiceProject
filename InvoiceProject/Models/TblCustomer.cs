using System;
using System.Collections.Generic;

namespace InvoiceProject.Models;

public partial class TblCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? Mobile { get; set; }

    public string? City { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<TblinvoiceDetail> TblinvoiceDetails { get; set; } = new List<TblinvoiceDetail>();
}
