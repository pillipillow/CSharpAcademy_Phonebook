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
            var contact = context.Contacts.Where(n => n.Name.Contains(name)).OrderBy(n=>n);
            return contact.ToList();  
        }
    }

}
