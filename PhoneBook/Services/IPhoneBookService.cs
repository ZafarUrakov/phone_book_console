using System.Collections.Generic;

namespace PhoneBook.Services
{
    internal interface IPhoneBookService
    {
        string AddUser(string userName, string phoneNumber);
        List<string> RetrieveAllContacts();
        string RetrieveContact(string userName);
        string ModifyContact(string userName, string newPhoneNumber);
        bool RemoveContact(string userName);
    }
}
