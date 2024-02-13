using Accountant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class InvoiceItemAddVM
{
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Guid InvoiceId { get; set; }
}
