using Upd8.Web.Services;
using Upd8.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("Upd8Api", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:Upd8Api"]);
});

builder.Services.AddHttpClient("Upd8ApiCidade", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUri:Upd8ApiCidade"]);
});

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICidadeService, CidadeService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
