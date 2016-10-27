using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Model
{
    public class UserContext : DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<InformationItem> InformationItems { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PhoneBook.db");

        }

    }
}
