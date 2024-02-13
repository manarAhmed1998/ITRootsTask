using Accountant.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.BL;

public class InvoiceItemsManager : IInvoiceItemsManager
{
    private readonly IUnitOfWork _unitOfWork;

    public InvoiceItemsManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<InvoiceItemReadVM> GetAll()
    {
        IEnumerable<InvoiceItem> itemsFromDB = _unitOfWork.InvoiceItemsRepo.GetAll();
        IEnumerable<InvoiceItemReadVM> itemsVM = itemsFromDB
            .Select(i => new InvoiceItemReadVM
            {
                Id=i.Id,
                Description=i.Description,
                Price = i.Price,
                Quantity = i.Quantity,
            });
        return itemsVM;
    }

    public void Add(InvoiceItemAddVM itemToAdd) {
        InvoiceItem item = new InvoiceItem
        {
            Id = Guid.NewGuid(),
            Description = itemToAdd.Description,
            Quantity = itemToAdd.Quantity,
            Price = itemToAdd.Price,
            InvoiceId = itemToAdd.InvoiceId
        };
        _unitOfWork.InvoiceItemsRepo.Add(item);
        //_unitOfWork.Save(); no server side changes
    }
}
