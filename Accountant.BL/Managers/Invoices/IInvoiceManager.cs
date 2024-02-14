using Accountant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public interface IInvoiceManager
{
    IEnumerable<InvoiceReadVM> GetAll();
    void Add(InvoiceAddVM invoiceToAdd);

    InvoiceReadVM? GetById(Guid id);
}
