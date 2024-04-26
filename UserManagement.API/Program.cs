using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using UserManagement.API.CollectionServices;
using UserManagement.API.Data;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("UserMgmtAPI");
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureRepositoryWrapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.WithOrigins("https://localhost:7210", "https://localhost:7210")
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .WithHeaders(HeaderNames.ContentType)
    );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
