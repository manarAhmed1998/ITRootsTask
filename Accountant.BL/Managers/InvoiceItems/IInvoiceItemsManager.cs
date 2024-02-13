using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public interface IInvoiceItemsManager
{
    IEnumerable<InvoiceItemReadVM> GetAll();
    void Add(InvoiceItemAddVM itemToAdd);
}