using Microsoft.Extensions.Hosting;
using SQL_Dapper.Services;
using Microsoft.Extensions.DependencyInjection;
using SQL_Dapper.Repositories;

var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hwila\source\repos\SQL-Dapper\SQL-Dapper\Data\LocalDBDapper.mdf;Integrated Security=True;Connect Timeout=30";

var app = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton(new CustomerRepository(connectionString));
    services.AddSingleton(new AddressRepository(connectionString));
    services.AddSingleton<CustomerServices>();
    services.AddSingleton<MenuServices>();

}).Build();
app.Start();
Console.Clear();

var menuServices = app.Services.GetRequiredService<MenuServices>();
menuServices.CreateNewCustomerMenu();


