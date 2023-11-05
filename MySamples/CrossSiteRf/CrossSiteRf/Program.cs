using CrossSiteRf.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAntiforgery(options =>
{
    /*
     * Specifies whether to suppress the generation of X-Frame-Options header which is used to prevent ClickJacking.
     * By default, the X-Frame-Options header is generated with the value SAMEORIGIN.
     * If this setting is 'true', the X-Frame-Options header will not be generated for the response.
     */
    options.SuppressXFrameOptionsHeader = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession(); 
StaticHttpContext.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());
StaticHttpContext.Current?.Session.SetString("ShoppingCart", string.Empty);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();