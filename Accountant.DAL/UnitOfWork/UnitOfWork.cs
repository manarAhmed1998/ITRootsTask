using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

//this bag has all of your repos and saveChanges method
//only getting repos so no set; needed
public class UnitOfWork : IUnitOfWork
{
    private readonly AccountantContext _context;
    public IInvoiceItemsRepo InvoiceItemsRepo { get;}
    public IInvoicesRepo InvoicesRepo { get;}

    public IUsersRepo UsersRepo {  get;}

    public UnitOfWork(AccountantContext context,
        IInvoicesRepo invoicesRepo,
        IInvoiceItemsRepo invoiceItemsRepo,
        IUsersRepo usersRepo)
    {
        _context = context;
        InvoicesRepo = invoicesRepo;
        InvoiceItemsRepo = invoiceItemsRepo;
        UsersRepo = usersRepo;
    }
    public int Save()
    {
        return _context.SaveChanges();
    }
}
