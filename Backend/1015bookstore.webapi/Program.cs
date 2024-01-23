using _1015bookstore.application.Catalog.Carts;
using _1015bookstore.application.Catalog.Categories;
using _1015bookstore.application.Catalog.Orders;
using _1015bookstore.application.Catalog.ProductIsnCategories;
using _1015bookstore.application.Catalog.Products;
using _1015bookstore.application.Catalog.PromotionalCodes;
using _1015bookstore.application.Catalog.Reviews;
using _1015bookstore.application.Common;
using _1015bookstore.application.Helper;
using _1015bookstore.application.System.Chats;
using _1015bookstore.application.System.Reports;
using _1015bookstore.application.System.UserAddresses;
using _1015bookstore.application.System.Users;
using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.utilities.Constants;
using _1015bookstore.webapi.Chat;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<_1015DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<_1015DbContext>().AddDefaultTokenProviders();

builder.Services.AddSignalR();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IProductInCategoryService,  ProductInCategoryService>();
builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
builder.Services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IPromotionalCodeService, PromotionalCodeService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IRemoveUnicode, RemoveUnicode>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IReportService, ReportService>();
builder.Services.AddTransient<IUserAddressService, UserAddressService>();
builder.Services.AddTransient<IChatService, ChatService>();


builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        ClockSkew = System.TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]))
    };
}
);

builder.Services.AddCors(p => p.AddPolicy("1015BookStore_Cors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7111")
                .AllowAnyHeader()
                .WithMethods("GET", "POST")
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors();
app.UseCors("1015BookStore_Cors");

app.MapHub<ChatHub>("/chat");

app.MapControllers();

app.Run();
