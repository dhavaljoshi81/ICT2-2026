var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//string inventoryApiUrl = builder.Configuration["InventoryAPI"];
//Console.WriteLine($"Inventory API URL: {inventoryApiUrl}");
//builder.Services.AddHttpClient("InventoryApi", c => c.BaseAddress = new Uri(inventoryApiUrl));

builder.Services.AddHttpClient("InventoryApi", 
    c => c.BaseAddress = new Uri(builder.Configuration["InventoryAPI"]));

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
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
