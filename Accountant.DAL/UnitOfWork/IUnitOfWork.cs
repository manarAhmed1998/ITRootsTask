using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public interface IUnitOfWork
{
    //this bag has all of your repos and saveChanges method
    //only getting repos so no set; needed
    IInvoicesRepo InvoicesRepo { get; }
    IInvoiceItemsRepo InvoiceItemsRepo { get; }
    IUsersRepo UsersRepo { get; }

    int Save();
}
