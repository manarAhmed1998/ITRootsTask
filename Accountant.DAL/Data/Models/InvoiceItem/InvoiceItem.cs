using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class InvoiceItem
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public string? Description { get; set; }
    public int Quantity {  get; set; }
    public decimal Price { get; set; }

    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = null!;

}
