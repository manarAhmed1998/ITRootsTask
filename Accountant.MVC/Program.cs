using Accountant.BL;
using Accountant.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region Services & context

// Add services to the container.
builder.Services.AddControllersWithViews();

//configure context service in the Dependency injection containe(for when any class requests a context in the ctor)
var connectionString = builder.Configuration.GetConnectionString("Accountant_Connection_String");
builder.Services.AddDbContext<AccountantContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IInvoicesRepo, InvoicesRepo>();
builder.Services.AddScoped<IInvoiceItemsRepo, InvoiceItemsRepo>();
builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IInvoiceManager, InvoiceManager>();
builder.Services.AddScoped<IInvoiceItemsManager, InvoiceItemsManager>();
builder.Services.AddScoped<IUsersManager, UsersManager>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
