using _1015bookstore.websiteadmin.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Index/";
                    options.AccessDeniedPath = "/User/Forbidden/";
                });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin",
        policy => policy.RequireClaim("Role", "admin"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(3);
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}

builder.Services.AddTransient<IUserAPIClient, UserAPIClient>();
builder.Services.AddTransient<IProductAPIClient, ProductAPIClient>();
builder.Services.AddTransient<ICategoryAPIClient, CategoryAPIClient>();
builder.Services.AddTransient<IReportAPIClient, ReportAPIClient>();
builder.Services.AddTransient<IPromotionalCodeAPIClient, PromotionalCodeAPIClient>();

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

//var pathroot = builder.Environment.WebRootPath;
//string frontendUrlPath = "/user-content";

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider("D:\\Data\\MonHoc\\Web-SE347\\Project\\1015bookstore__git\\1015Bookstore\\Frontend\\src\\assets\\user-content"),
//    RequestPath = new PathString(frontendUrlPath)
//});

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseSession();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
