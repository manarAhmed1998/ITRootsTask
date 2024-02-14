using Accountant.BL;
using Accountant.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Accountant.MVC.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceManager _invoiceManager;
        private readonly AccountantContext _context;
        public InvoiceController(IInvoiceManager invoiceManager,AccountantContext context)
        {
            _invoiceManager = invoiceManager;
            _context = context;
        }
        public IActionResult Index()
        {
           IEnumerable<InvoiceReadVM> invoices= _invoiceManager.GetAll();
            return View(invoices);
        }
        public IActionResult CreateInvoicePartial()
        {
            return PartialView("_CreateInvoice", new Invoice());
        }


        public async Task<IActionResult> CreateNewInvoice([FromBody] Invoice invoice)
        {
            if (invoice != null)
            {

                Invoice myinvoice = new Invoice();
                myinvoice.Id = invoice.Id;

                List<InvoiceItem> items = new List<InvoiceItem>();
                foreach (var item in invoice.InvoiceItems)
                {
                    InvoiceItem product = new InvoiceItem();
                    product.Description = item.Description;
                    product.Quantity = item.Quantity;
                    product.Price = item.Quantity;
                    product.InvoiceId = myinvoice.Id;
                    items.Add(product);
                }
                myinvoice.InvoiceItems = items;

                await _context.Invoices.AddAsync(myinvoice);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
