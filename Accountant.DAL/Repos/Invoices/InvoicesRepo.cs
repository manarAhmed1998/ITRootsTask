using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class InvoicesRepo : GenericRepo<Invoice>, IInvoicesRepo
{
    private readonly AccountantContext _context;

    public InvoicesRepo(AccountantContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<Invoice> GetInvoicesWithItems()
    {
        return _context.Invoices.Include(i => i.InvoiceItems);  
            
            
    }
}
