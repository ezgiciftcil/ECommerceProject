
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.; database=ECommerceDb; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userTypeBuilder=modelBuilder.Entity<UserType>();
            userTypeBuilder.HasKey(e => new { e.UserTypeId });
            userTypeBuilder.Property(e => e.UserTypeId).ValueGeneratedOnAdd();
            userTypeBuilder.Property(e => e.TypeName).IsRequired().HasMaxLength(20);

            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.HasKey(e => new { e.UserId });
            userBuilder.Property(e => e.UserId).ValueGeneratedOnAdd();
            userBuilder.Property(e => e.Email).IsRequired().HasMaxLength(320);
            userBuilder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            userBuilder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            userBuilder.Property(e => e.Password).IsRequired().HasMaxLength(12);
            userBuilder.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(11);
            userBuilder.HasOne<UserType>(e => e.UserType)
            .WithMany(d => d.Users)
            .HasForeignKey(e => e.UserTypeId);

            var cityBuilder = modelBuilder.Entity<City>();
            cityBuilder.HasKey(e => new { e.CityId });
            cityBuilder.Property(e => e.CityId).ValueGeneratedOnAdd();
            cityBuilder.Property(e => e.CityName).IsRequired().HasMaxLength(30);

            var addressBuilder = modelBuilder.Entity<Address>();
            addressBuilder.HasKey(e => new { e.AddressId });
            addressBuilder.Property(e => e.AddressId).ValueGeneratedOnAdd();
            addressBuilder.Property(e => e.AddressDescription).IsRequired();
            addressBuilder.Property(e => e.Country).IsRequired();
            addressBuilder.Property(e => e.PostCode).IsRequired().HasMaxLength(20);
            addressBuilder.Property(e => e.Street).IsRequired().HasMaxLength(70);
            addressBuilder.HasOne<User>(e => e.User)
            .WithMany(d => d.Addresses)
            .HasForeignKey(e => e.UserId);
            addressBuilder.HasOne<City>(e => e.City)
            .WithMany(d => d.Addresses)
            .HasForeignKey(e => e.CityId);

            var categoryBuilder = modelBuilder.Entity<Category>();
            categoryBuilder.HasKey(e => new { e.CategoryId });
            categoryBuilder.Property(e => e.CategoryId).ValueGeneratedOnAdd();
            categoryBuilder.Property(e => e.CategoryName).IsRequired().HasMaxLength(50);

            var productBuilder = modelBuilder.Entity<Product>();
            productBuilder.HasKey(e => new { e.ProductId });
            productBuilder.Property(e => e.ProductId).ValueGeneratedOnAdd();
            productBuilder.Property(e => e.Description).IsRequired();
            productBuilder.Property(e => e.ImageUrl).IsRequired();
            productBuilder.Property(e => e.Price).IsRequired();
            productBuilder.Property(e => e.Stock).IsRequired();
            productBuilder.HasOne<Category>(e => e.Category)
            .WithMany(d => d.Products)
            .HasForeignKey(e => e.CategoryId);

            var discountBuilder = modelBuilder.Entity<Discount>();
            discountBuilder.HasKey(e => new { e.DiscountId });
            discountBuilder.Property(e => e.DiscountId).ValueGeneratedOnAdd();
            discountBuilder.Property(e => e.CreatedDate).IsRequired();
            discountBuilder.Property(e => e.DiscountDescription).IsRequired().HasMaxLength(150);
            discountBuilder.Property(e => e.IsActive).IsRequired();
            discountBuilder.Property(e => e.LastDate).IsRequired();
            discountBuilder.Property(e => e.DiscountPercent).IsRequired();
            discountBuilder.HasOne<Product>(e => e.Product)
            .WithMany(d => d.Discounts)
            .HasForeignKey(e => e.ProductId);

            var cartBuilder = modelBuilder.Entity<Cart>();
            cartBuilder.HasKey(e => new { e.CartId });
            cartBuilder.Property(e => e.CartId).ValueGeneratedOnAdd();
            cartBuilder.HasOne<User>(e => e.User)
            .WithMany(d => d.Carts)
            .HasForeignKey(e => e.UserId);

            var cartItemBuilder = modelBuilder.Entity<CartItem>();
            cartItemBuilder.HasKey(e => new { e.CartItemId });
            cartItemBuilder.Property(e => e.CartItemId).ValueGeneratedOnAdd();
            cartItemBuilder.Property(e => e.AddedDate).IsRequired();
            cartItemBuilder.HasOne<Cart>(e => e.Cart)
            .WithMany(d => d.CartItems)
            .HasForeignKey(e => e.CartItemId);
            cartItemBuilder.HasOne<Product>(e => e.Product)
            .WithMany(d => d.CartItems)
            .HasForeignKey(e => e.ProductId);

            var wishingListBuilder = modelBuilder.Entity<WishingList>();
            wishingListBuilder.HasKey(e => new { e.WishingListId });
            wishingListBuilder.Property(e => e.WishingListId).ValueGeneratedOnAdd();
            wishingListBuilder.HasOne<User>(e => e.User)
            .WithMany(d => d.WishingLists)
            .HasForeignKey(e => e.UserId);

            var wishingListItemBuilder = modelBuilder.Entity<WishingListItem>();
            wishingListItemBuilder.HasKey(e => new { e.WishingListItemId });
            wishingListItemBuilder.Property(e => e.WishingListItemId).ValueGeneratedOnAdd();
            wishingListItemBuilder.HasOne<Product>(e => e.Product)
            .WithMany(d => d.WishingListItems)
            .HasForeignKey(e => e.ProductId);
            wishingListItemBuilder.HasOne<WishingList>(e => e.WishingList)
            .WithMany(d => d.WishingListItems)
            .HasForeignKey(e => e.WishingListId);
        }
        
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<WishingList> WishingLists { get; set; }
        public DbSet<WishingListItem> WishingListItems { get; set; }
    }
}
