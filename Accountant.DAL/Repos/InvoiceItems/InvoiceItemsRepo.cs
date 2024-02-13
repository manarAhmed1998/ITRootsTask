using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class InvoiceItemsRepo : GenericRepo<InvoiceItem>, IInvoiceItemsRepo
{
    private readonly AccountantContext _context;
    public InvoiceItemsRepo(AccountantContext context) : base(context)
    {
        _context = context;
    }
}
