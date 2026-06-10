using Microsoft.EntityFrameworkCore;
using Phonebook.Model;

namespace Phonebook;

internal class PhonebookContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PhonebookDB;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, Name = "John Doe", PhoneNumber = "110000111", EmailAddress = "johnDoe@gmail.com"},
            new Contact { Id = 2, Name = "John Doe", PhoneNumber = "114345111", EmailAddress = "john.doe@gmail.com"},
            new Contact { Id = 3, Name = "Mary Jane", PhoneNumber = "110500631", EmailAddress = "maryjane@gmail.com"},
            new Contact { Id = 4, Name = "Alice Green", PhoneNumber = "120305141", EmailAddress = "alicegreen@gmail.com"},
            new Contact { Id = 5, Name = "Bob Vance", PhoneNumber = "120775991", EmailAddress = "bobvance@gmail.com" }
        );
    }
}
