using Accountant.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accountant.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceManager _invoiceManager;
        public InvoiceController(IInvoiceManager invoiceManager)
        {
            _invoiceManager = invoiceManager;
        }
        public IActionResult Index()
        {
           var invoices= _invoiceManager.GetAll();
            return View(invoices);
        }
    }
}
