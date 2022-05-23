
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
        }
        
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
