using System;
using PhoneBook.Services;

class Program
{
    private static readonly IPhoneBookService phoneBookService = new PhoneBookService();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Phone Book Menu:");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Retrieve All Contacts");
            Console.WriteLine("3. Retrieve Contact");
            Console.WriteLine("4. Modify Contact");
            Console.WriteLine("5. Remove Contact");
            Console.WriteLine("6. Exit");
            Console.Write("Please enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter user name: ");
                    string userName = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    string phoneNumber = Console.ReadLine();
                    string addedUser = phoneBookService.AddUser(userName, phoneNumber);
                    Console.WriteLine(addedUser != null ? "User added successfully." : "Failed to add user.");
                    break;
                case "2":
                    Console.WriteLine("Retrieving all contacts:");
                    var allContacts = phoneBookService.RetrieveAllContacts();
                    if (allContacts != null)
                    {
                        foreach (var contact in allContacts)
                        {
                            Console.WriteLine(contact);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve contacts.");
                    }
                    break;
                case "3":
                    Console.Write("Enter user name: ");
                    string contactName = Console.ReadLine();
                    string retrievedContact = phoneBookService.RetrieveContact(contactName);
                    Console.WriteLine(retrievedContact != null ? $"Contact: {retrievedContact}" : "Contact not found.");
                    break;
                case "4":
                    Console.Write("Enter user name: ");
                    string modifyUserName = Console.ReadLine();
                    Console.Write("Enter new phone number: ");
                    string newPhoneNumber = Console.ReadLine();
                    string modifiedUser = phoneBookService.ModifyContact(modifyUserName, newPhoneNumber);
                    Console.WriteLine(modifiedUser != null ? "Contact modified successfully." : "Failed to modify contact.");
                    break;
                case "5":
                    Console.Write("Enter user name: ");
                    string removeUserName = Console.ReadLine();
                    bool removed = phoneBookService.RemoveContact(removeUserName);
                    Console.WriteLine(removed ? "Contact removed successfully." : "Failed to remove contact.");
                    break;
                case "6":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
