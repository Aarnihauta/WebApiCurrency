using System.Net;
using WebApiCurrency.IoC;

var builder = WebApplication.CreateBuilder(args);

#region configuring http client
builder.Services.AddHttpClient("currencyClient", c =>
{
    c.BaseAddress = new Uri("https://www.cbr-xml-daily.ru/");
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    IWebProxy proxy = WebRequest.GetSystemWebProxy();
    var item = new HttpClientHandler();
    item.Proxy = proxy;
    item.Proxy.Credentials = CredentialCache.DefaultCredentials;
    return item;
});
#endregion

builder.Services.AddControllers();
builder.Services.AddTransient<ICurrentCurrency, CurrentCurrency>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.UseRouting();

app.Run();
