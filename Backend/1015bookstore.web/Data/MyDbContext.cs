using _1015bookstore.web.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace _1015bookstore.web.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) 
        { 
            
        }

        #region Dbset
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<PromotionalCode> PromotionalCodes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TypedCategories_Promotionals> typedCategories_Promotionals { get; set; }
        public DbSet<TypedProducts_Promotionals> typedProducts_Promotionals { get; set; }
        public DbSet<TypedUsers_Promotionals> typedUsers_Promotionals { get; set; }
        public DbSet<TypedUserTypes_Promotionals> typedUserTypes_Promotionals { get; set; }
        public DbSet<TypedUsers_UserTypes> typedUsers_UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new {e.product_id, e.user_id});

                entity.HasOne(e => e.user)
                .WithMany(e => e.cartitems)
                .HasForeignKey(e => e.user_id)
                .HasConstraintName("FK_CartItem_User");

                entity.HasOne(e => e.product)
                .WithMany(e => e.cartitems)
                .HasForeignKey(e => e.product_id)
                .HasConstraintName("FK_CartItem_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.id);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.HasOne(e => e.user)
                .WithMany(e => e.orders)
                .HasForeignKey(e => e.user_id)
                .HasConstraintName("FK_Order_User");

            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new {e.product_id, e.order_id});

                entity.HasOne(e => e.product)
                .WithMany(e => e.orderdetails)
                .HasForeignKey(e => e.product_id)
                .HasConstraintName("FK_Orderdetail_Product");

                entity.HasOne(e => e.order)
                .WithMany(e => e.orderdetails)
                .HasForeignKey(e => e.order_id)
                .HasConstraintName("FK_Orderdetail_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.HasOne(e => e.category)
                .WithMany(e => e.products)
                .HasForeignKey(e => e.category_id)
                .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasKey(e => e.product_id);
            });

            modelBuilder.Entity<PromotionalCode>(entity =>
            {
                entity.HasKey(e => e.id);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.HasOne(e => e.user)
                .WithMany(e => e.reviews)
                .HasForeignKey(e => e.user_id)
                .HasConstraintName("FK_Review_User");

                entity.HasOne(e => e.product)
                .WithMany(e => e.reviews_)
                .HasForeignKey(e => e.product_id)
                .HasConstraintName("FK_Review_Product");
            });

            modelBuilder.Entity<TypedCategories_Promotionals>(entity =>
            {
                entity.HasKey(e => new { e.category_id, e.promotional_id });

                entity.HasOne(e => e.category)
                .WithMany(e => e.typedcategories_promotionals)
                .HasForeignKey(e => e.category_id)
                .HasConstraintName("FK_TypeCategories_Promotionals_1");

                entity.HasOne(e => e.promotionalcodes)
                .WithMany(e => e.typedcategories_promotionals)
                .HasForeignKey(e => e.promotional_id)
                .HasConstraintName("FK_TypeCategories_Promotionals_2");
            });

            modelBuilder.Entity<TypedProducts_Promotionals>(entity =>
            {
                entity.HasKey(e => new {e.product_id, e.promotional_id});

                entity.HasOne(e => e.product)
                .WithMany(e => e.typedproducts_promotionals)
                .HasForeignKey(e => e.product_id)
                .HasConstraintName("FK_TypeProducts_Promotionals_1");

                entity.HasOne(e => e.promotionalcodes)
                .WithMany(e => e.typedproducts_promotionals)
                .HasForeignKey(e => e.promotional_id)
                .HasConstraintName("FK_TypeProducts_Promotionals_2");
            });

            modelBuilder.Entity<TypedUsers_Promotionals>(entity =>
            {
                entity.HasKey(e => new { e.user_id, e.promotional_id });

                entity.HasOne(e => e.user)
                .WithMany(e => e.typedusers_promotionals)
                .HasForeignKey(e => e.user_id)
                .HasConstraintName("FK_TypeUsers_Promotionals_1");

                entity.HasOne(e => e.promotionalcodes)
                .WithMany(e => e.typedusers_promotionals)
                .HasForeignKey(e => e.promotional_id)
                .HasConstraintName("FK_TypeUsers_Promotionals_2");
            });

            modelBuilder.Entity<TypedUsers_UserTypes>(entity =>
            {
                entity.HasKey(e => new { e.user_id, e.usertype_id });

                entity.HasOne(e => e.user)
                .WithMany(e => e.typedusers_usertypes)
                .HasForeignKey(e => e.user_id)
                .HasConstraintName("FK_TypeUsers_UserTypes_1");

                entity.HasOne(e => e.usertype)
                .WithMany(e => e.typedusers_usertypes)
                .HasForeignKey(e => e.usertype_id)
                .HasConstraintName("FK_TypeUsers_UserTypes_2");
            });

            modelBuilder.Entity<TypedUserTypes_Promotionals>(entity =>
            {
                entity.HasKey(e => new { e.usertype_id, e.promotional_id });

                entity.HasOne(e => e.usertype)
                .WithMany(e => e.typedusertypes_promotionals)
                .HasForeignKey(e => e.usertype_id)
                .HasConstraintName("FK_TypeUserTypes_Promotionals_1");

                entity.HasOne(e => e.promotionalcodes)
                .WithMany(e => e.typedusertypes_promotionals)
                .HasForeignKey(e => e.promotional_id)
                .HasConstraintName("FK_TypeUserTypes_Promotionals_2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.id);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.HasOne(e => e.user)
                .WithMany(e => e.useraddresses)
                .HasForeignKey(e => e.user_id)
                .HasConstraintName("FK_UserAddress_User");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.id);
            });
        }
    }
}
