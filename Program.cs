using WebApiCurrency.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<ICurrentCurrency, CurrentCurrency>();
var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.UseRouting();

app.Run();
