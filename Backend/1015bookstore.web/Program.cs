using _1015bookstore.web.Data;
using _1015bookstore.web.Data.Entity;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));

});

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserAddressRepository,UserAddressRepository>();
builder.Services.AddScoped<IUserTypeRepository,UserTypeRepository>();
builder.Services.AddScoped<IPromotionalCodeRepository,PromotionalCodeRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICartItemRepository,CartItemRepository>();
builder.Services.AddScoped<ITypedCategories_PromotionalsRepository,TypedCategories_PromotionalsRepository>();
builder.Services.AddScoped<ITypedProducts_PromotionalsRepository, TypedProducts_PromotionalsRepository>();
builder.Services.AddScoped<ITypedUsers_PromotionalsRepository, TypedUsers_PromotionalsRepository>();
builder.Services.AddScoped<ITypedUserTypes_PromotionalsRepository, TypedUserTypes_PromotionalsRepository>();
builder.Services.AddScoped<ITypedUsers_UserTypesRepository, TypedUsers_UserTypesRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Serect"]))
    };
});

builder.Services.AddCors(p => p.AddPolicy("1015BookStore_Cors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("1015BookStore_Cors");

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
