using _1015bookstore.data.Entities;
using _1015bookstore.data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { key = "HomeTitle", value = "This is home page of eShopSolution" },
               new AppConfig() { key = "Homekeyword", value = "This is keyword of eShopSolution" },
               new AppConfig() { key = "HomeDescription", value = "This is description of eShopSolution" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    id = 1,
                    name = "Sách giáo khoa",
                    categoryparentid = 0,
                    createdby = "HeThong",
                    datecreated = DateTime.Now,
                    updatedby = "HeThong",
                    dateupdated = DateTime.Now,
                    status = CategoryStatus.Normal,
                    show = CategoryShow.Taskbar,
                },
                 new Category()
                 {
                     id = 2,
                     name = "Sách ngôn ngữ",
                     categoryparentid = 0,
                     createdby = "HeThong",
                     datecreated = DateTime.Now,
                     updatedby = "HeThong",
                     dateupdated = DateTime.Now,
                     status = CategoryStatus.Normal,
                     show = CategoryShow.Taskbar,
                 },
                 new Category()
                 {
                     id = 3,
                     name = "Sách giáo khoa lớp 1",
                     categoryparentid = 1,
                     createdby = "HeThong",
                     datecreated = DateTime.Now,
                     updatedby = "HeThong",
                     dateupdated = DateTime.Now,
                     status = CategoryStatus.Normal,
                     show = CategoryShow.Taskbar,
                 },
                 new Category()
                 {
                     id = 4,
                     name = "Sách tiếng anh",
                     categoryparentid = 2,
                     createdby = "HeThong",
                     datecreated = DateTime.Now,
                     updatedby = "HeThong",
                     dateupdated = DateTime.Now,
                     status = CategoryStatus.Normal,
                     show = CategoryShow.Taskbar,
                 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    id = 1,
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
                    brand = "",
                    madein = "",
                    mfgdate = new DateTime(2023,12,10),
                    suppiler = "",
                    author = "",
                    nop = "",
                    yop = 2023,
                    createdby = "HeThong",
                    datecreated = DateTime.Now,
                    updatedby = "HeThong",
                    dateupdated = DateTime.Now,
                    status = ProductStatus.Normal,
                },
                new Product()
                {
                    id = 2,
                    name = "Sách phát âm Mai Lan Hương",
                    alias = "Sach phat am Mai Lan Huong",
                    price = 10000,
                    start_count = 0,
                    review_count = 0,
                    buy_count = 0,
                    flashsale = false,
                    like_count = 0,
                    waranty = 30,
                    quanity = 100,
                    view_count = 0,
                    description = "Đây là sách oke nè",
                    brand = "",
                    madein = "",
                    mfgdate = DateTime.Now,
                    suppiler = "",
                    author = "",
                    nop = "",
                    yop = 2023,
                    createdby = "HeThong",
                    datecreated = DateTime.Now,
                    updatedby = "HeThong",
                    dateupdated = DateTime.Now,
                    status = ProductStatus.Normal,
                }
            );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { product_id = 1, category_id = 3 },
                new ProductInCategory() { product_id = 2, category_id = 4 }
            );

            var admin_roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var user_roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DA");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = admin_roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    description = "Administrator role"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = user_roleId,
                    Name = "user",
                    NormalizedName = "user",
                    description = "User role"
                }
            );

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    Email = "21520208@gm.uit.edu.vn",
                    NormalizedEmail = "21520208@gm.uit.edu.vn",
                    PhoneNumber = "0907448146",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                    SecurityStamp = string.Empty,
                    firstname = "Nguyen",
                    lastname = "Duy",
                    dob = new DateTime(2003, 10, 23)
                }
            );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = admin_roleId,
                UserId = adminId
            });
        }
    }
}
