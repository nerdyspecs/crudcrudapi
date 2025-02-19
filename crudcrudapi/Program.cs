using crudcrudapi.Repositories;
using crudcrudapi.Services;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register HttpClient with CrudCrud base URL
builder.Services.AddHttpClient<ProductsRepository>(client =>
{
    client.BaseAddress = new Uri("https://crudcrud.com/api/f3929eb41f254e5fbeced579fc535dc2/");
    client.DefaultRequestHeaders.Add("Authorization", "f3929eb41f254e5fbeced579fc535dc2");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});



// Register repository and service in DI
//builder.Services.AddScoped<ProductsRepository>();
builder.Services.AddScoped<ProductsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
