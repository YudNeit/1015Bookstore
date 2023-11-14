using _1015bookstore.web.Data;
using _1015bookstore.web.Repository;
using _1015bookstore.web.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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
