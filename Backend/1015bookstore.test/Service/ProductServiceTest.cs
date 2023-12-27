using _1015bookstore.application.Catalog.Products;
using _1015bookstore.application.Common;
using _1015bookstore.application.Helper;
using _1015bookstore.data.EF;
using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using Microsoft.EntityFrameworkCore;
using _1015bookstore.viewmodel.Catalog.Products;

namespace _1015bookstore.test.Service
{
    [TestClass]
    public class ProductServiceTest
    {
        private readonly IStorageService _storageService;
        private readonly IRemoveUnicode _removeUnicode;

        public ProductServiceTest(IStorageService storageService, IRemoveUnicode removeUnicode)
        {
            _storageService = storageService;
            _removeUnicode = removeUnicode;
        }
        private async Task<_1015DbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<_1015DbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new _1015DbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Products.CountAsync() < 0)
            {
                for (var i = 0; i < 10; i++)
                {
                    await databaseContext.Products.AddAsync(
                        new Product
                        {
                            name = "Sách toán lớp 1",
                            alias = "Sach toan lop 1",
                            price = 10000,
                            start_count = 0,
                            review_count = 0,
                            buy_count = 0,
                            flashsale = false,
                            like_count = 0,
                            waranty = 30,
                            quanity = 100,
                            view_count = 0,
                            description = "Đây là sách toán hay dành cho trẻ em",
                            createdby = "HeThong",
                            datecreated = DateTime.Now,
                            updatedby = "HeThong",
                            dateupdated = DateTime.Now,
                            status = ProductStatus.Normal,
                        }
                    );
                    await databaseContext.SaveChangesAsync();
                }
                
            }    
            return databaseContext;
        }

        [TestMethod]
        public async Task ProductService_Create_ReturnsProductId()
        {
            //Arrange
            var product = new ProductCreateRequest
            {
                name = "Sách toán lớp 1",
                price = 10000,
                waranty = 30,
                quanity = 100,
                description = "Đây là sách toán hay dành cho trẻ em",

            };
            var dbContext = await GetDbContext();
            var productService = new ProductService(dbContext, _storageService, _removeUnicode);

            //Act
            var result = await productService.Create(product);
            Assert.IsNotNull(result);
            Assert.AreEqual(11, result);
        }
    }
}
