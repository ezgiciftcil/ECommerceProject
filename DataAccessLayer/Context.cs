
using EntityLayer;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class Context : DbContext
    {
        DbSet<UserType> UserTypes { get; set; }
        DbSet<User> Users { get; set; }

    }
}
