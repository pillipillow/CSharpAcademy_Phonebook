using Microsoft.EntityFrameworkCore;
using Phonebook.Model;

namespace Phonebook;

internal class DatabaseManager
{
    internal List<Contact> ViewContacts()
    {

        using (var context = new PhonebookContext())
        {
            var contacts = context.Contacts.ToList();

            return contacts;
        }
    }

    internal void AddContact(string name, string phoneNumber, string email)
    {
        using (var context = new PhonebookContext())
        {
            var contact = new Contact()
            {
                Name = name,
                PhoneNumber = phoneNumber,
                EmailAddress = email
            };

            context.Add(contact);
            context.SaveChanges();
        }
    }

    internal List<Contact> FindContact(string name)
    {
        using (var context = new PhonebookContext())
        {
            var contact = context.Contacts.Where(c => c.Name.Contains(name)).OrderBy(n => n);
            return contact.ToList();
        }
    }

    internal List<Contact> FindContactByIdAndName(int id, string name)
    {
        using (var context = new PhonebookContext())
        {
            var contact = context.Contacts.Where(c => c.Id == id && c.Name.Contains(name));
            return contact.ToList();
        }
    }

    internal void DeleteById(int id)
    {
        using (var context = new PhonebookContext())
        { 
            var rowsDeleted = context.Contacts.Where(c => c.Id == id).ExecuteDelete();
        }
    
    }

    internal void UpdateById(int id, string name, string phoneNumber, string email)
    {
        using (var context = new PhonebookContext())
        {
            context.Contacts.Where(c => c.Id == id).ExecuteUpdate(setter => 
            { 
                setter.SetProperty(c=>c.Name, name);    
                setter.SetProperty(c=>c.PhoneNumber, phoneNumber);
                setter.SetProperty(c=>c.EmailAddress, email);
            
            });
        }

    }
}
