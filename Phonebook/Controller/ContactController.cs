using Phonebook.Model;

namespace Phonebook.Controller;

internal class ContactController
{
    static DatabaseManager dbmanager = new DatabaseManager();
    static Helpers helpers = new Helpers();
    static List<Contact> contacts = new List<Contact>();

    internal static void ViewContacts()
    {
        contacts.Clear();

        Console.Clear();
        Console.WriteLine("---View all Contacts---");

        contacts = dbmanager.ViewContacts();

        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"E-mail: {contact.EmailAddress}");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Press enter to go back to the main menu.");
        Console.ReadLine();
    }

    internal static void NewContact()
    {
        Console.Clear();
        Console.WriteLine("---Add New Contact---");
        Console.WriteLine("Insert new contact name: ");
        string name = helpers.CheckName();

        if (name == "0") return;

        Console.WriteLine("Insert new contact phone number (00-0000-0000): ");
        string number = helpers.CheckPhoneNumber();

        if(number == "0") return;

        Console.WriteLine("Insert new contact email address:");
        string email = helpers.CheckEmail();

        dbmanager.AddContact(name, number, email);
        Console.WriteLine("\nNew Contact has been added in the Phonebook!");

        Console.WriteLine("Would you like to add another contact?: (Y/N)");
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input) && input.ToLower() == "y")
            NewContact();
        else
        {
            Console.WriteLine("Press enter to go back to the main menu.");
            Console.ReadLine();
        }
    }

    internal static void DeleteContact()
    {
        contacts.Clear();

        Console.Clear();
        Console.WriteLine("---Delete Contact---");

        Console.WriteLine("Press enter to go back to the main menu.");
        Console.ReadLine();

    }

    internal static void UpdateContact()
    {
        Console.Clear();
        Console.WriteLine("---Update Contact---");

        Console.WriteLine("Press enter to go back to the main menu.");
        Console.ReadLine();
    }

    internal static void FindContact()
    {
        contacts.Clear();

        Console.Clear();
        Console.WriteLine("---Find Contact---");
        Console.WriteLine("Insert the contact name: ");
        string input = helpers.CheckName();

        if (input == "0") return;

        contacts = dbmanager.FindContact(input);

        if (contacts.Count == 0)
        {
            Console.WriteLine("Contact not found\n");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("---Find Contact---");
            Console.WriteLine($"{contacts.Count} found\n");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"E-mail: {contact.EmailAddress}");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Press enter to go back to the main menu.");
        Console.ReadLine();
    }

    


}
