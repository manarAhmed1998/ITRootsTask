using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class Invoice
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Total {  get; set; }
    public ICollection<InvoiceItem>? InvoiceItems { get; set; }
        =new HashSet<InvoiceItem>();
}
