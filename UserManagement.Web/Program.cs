using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UserManagement.Web;
using UserManagement.Web.Services;
using UserManagement.Web.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7112/") });
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();

await builder.Build().RunAsync();
