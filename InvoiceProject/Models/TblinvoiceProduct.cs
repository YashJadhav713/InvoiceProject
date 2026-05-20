using System;
using System.Collections.Generic;

namespace InvoiceProject.Models;

public partial class TblinvoiceProduct
{
    public int InvoiceproductId { get; set; }

    public int? InvoiceId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual TblinvoiceDetail? Invoice { get; set; }

    public virtual TblProduct? Product { get; set; }
}
