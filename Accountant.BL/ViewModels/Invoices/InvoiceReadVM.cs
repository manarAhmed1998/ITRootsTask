using Accountant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class InvoiceReadVM
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Total { get; set; }
    public ICollection<InvoiceItem>? InvoiceItems { get; set; }
       = new HashSet<InvoiceItem>();


}
