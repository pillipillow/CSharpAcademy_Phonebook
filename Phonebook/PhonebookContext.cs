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
}
