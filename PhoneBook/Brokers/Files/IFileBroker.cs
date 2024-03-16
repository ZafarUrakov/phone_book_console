using System.Collections.Generic;

namespace PhoneBook.Brokers.Files
{
    internal interface IFileBroker
    {
        string CreateContact(string userName, string phoneNumber);
        List<string> ViewContacts();
        string FindContact(string userName);
        string UpdateContact(string userName, string newPhoneNumber);
        bool DeleteContact(string userName);
    }
}
