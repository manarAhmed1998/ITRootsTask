using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.DAL;

public class AccountantContext:DbContext
{
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    public DbSet<User> Users => Set<User>();

    public AccountantContext(DbContextOptions<AccountantContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //adding to the orginal code
        base.OnModelCreating(modelBuilder);

        #region seeding
        // Seed Invoices
        //modelBuilder.Entity<Invoice>().HasData(
        //    new Invoice { Id = Guid.Parse("d3440d48-8f0c-4d09-afbe-6abd8f9463f0"), Date = DateTime.Now,Total=30.5M},
        //    new Invoice { Id= Guid.Parse("a3440d48-8f0c-4d09-afbe-6abd8f9463f0"), Date = DateTime.Now,Total=11},
        //    new Invoice { Id = Guid.Parse("b3440d48-8f0c-4d09-afbe-6abd8f9463f0"), Date = DateTime.Now,Total=50 },
        //    new Invoice { Id = Guid.Parse("c3440d48-8f0c-4d09-afbe-6abd8f9463f0"), Date = DateTime.Now,Total=101 }
        //);

        #endregion
    }

}
