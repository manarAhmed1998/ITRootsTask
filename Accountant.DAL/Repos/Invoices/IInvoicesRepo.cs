using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public interface IInvoicesRepo:IGenericRepo<Invoice>
{
    IEnumerable<Invoice> GetInvoicesWithItems();
}
