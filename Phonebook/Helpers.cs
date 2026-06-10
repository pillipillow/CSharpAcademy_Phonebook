using System.Text.RegularExpressions;

namespace Phonebook;

internal class Helpers
{
    const string PHONE_PATTERN = @"^\+?(\d{1,3})?[-. ]?\(?\d{3}\)?[-. ]?\d{3}[-. ]?\d{4}$";
    const string EMAIL_PATTERN = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

    internal string CheckName()
    {
        string name = "";
        bool isValid = false;

        do
        {
            name = Console.ReadLine();
            if (name == "0")
                isValid = true;

            if (string.IsNullOrWhiteSpace(name))
                Console.WriteLine("Name cannot be empty. Try again: ");
            else
                isValid = true;

        } while (!isValid);

        return name;
    }

    internal int CheckNumber()
    {
        int number = 0;
        bool isValid = false;
        do
        { 
            string input = Console.ReadLine();
            if (input == "0")
            {
                number = 0;
                isValid = true;
            }

            if (string.IsNullOrWhiteSpace(input))
                Console.WriteLine("ID cannot be empty. Try again: ");
            else
            { 
                if(int.TryParse(input, out number))
                    isValid = true;
                else
                    Console.WriteLine($"ID is not a number.Try again: ");
            
            }

        }while (!isValid);

        return number;
    
    }

    internal string CheckPhoneNumber()
    {
        string number = "";
        bool isValid = false;

        do
        {
            number = Console.ReadLine();
            if(number == "0")
                isValid = true;

            if (Regex.IsMatch(number, PHONE_PATTERN))
                isValid = true;
            else
            { 
                Console.WriteLine("Not a valid phone number. Try again: ");
            }
        }
        while (!isValid);

        return number;
    }


    internal string CheckEmail()
    {
        string email = "";
        bool isValid = false;

        do
        {
            email = Console.ReadLine();
            if (email == "0")
                isValid = true;

            if (Regex.IsMatch(email, EMAIL_PATTERN))
                isValid = true;
            else
                Console.WriteLine("Not a valid email. Try again: ");
        }
        while (!isValid);
        
        return email;
    }
}
