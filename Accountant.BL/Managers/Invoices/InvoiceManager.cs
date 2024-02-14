using Accountant.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class InvoiceManager : IInvoiceManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvoicesRepo _invoicesRepo;
    public InvoiceManager(IUnitOfWork unitOfWork, IInvoicesRepo invoicesRepo)
    {
        _unitOfWork = unitOfWork;
        _invoicesRepo = invoicesRepo;
    }

    public void Add(InvoiceAddVM invoiceToAdd)
    {
        var invoice = new Invoice
        {
            Id = Guid.NewGuid(),
            Total = invoiceToAdd.Total,
            Date = invoiceToAdd.Date,
            InvoiceItems = invoiceToAdd.InvoiceItems
        };
        _unitOfWork.InvoicesRepo.Add(invoice);
        _unitOfWork.Save(); //server side change
    }

    public IEnumerable<InvoiceReadVM> GetAll()
    {
        var invoicesFromDB=_invoicesRepo.GetInvoicesWithItems();
        IEnumerable<InvoiceReadVM> invoicesVM = invoicesFromDB
            .Select(i => new InvoiceReadVM
            {
                Id = i.Id,
                Date = i.Date,
                Total = i.Total,
                InvoiceItems = i.InvoiceItems
            });
        return invoicesVM;
    }

    public InvoiceReadVM? GetById(Guid id)
    {
        Invoice? invoice=_unitOfWork.InvoicesRepo.GetById(id);
        if (invoice == null) { return null; }
        else
        {
            InvoiceReadVM invoiceVM = new InvoiceReadVM()
            {
                Id = id,
                Date = invoice.Date,
                Total = invoice.Total,
                InvoiceItems = invoice.InvoiceItems
            };
            return invoiceVM;
        }
    }
}
