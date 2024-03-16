using System;
using System.Collections.Generic;
using PhoneBook.Brokers.Files;
using PhoneBook.Brokers.Loggings;

namespace PhoneBook.Services
{
    internal class PhoneBookService : IPhoneBookService
    {
        private readonly IFileBroker fileBroker = new FileBroker();
        private readonly ILoggingBroker loggingBroker = new LoggingBroker();

        public string AddUser(string userName, string phoneNumber)
        {
            try
            {
                var addedUser = this.fileBroker.CreateContact(userName, phoneNumber);
                loggingBroker.LogInformation("Contact successfully added");

                return addedUser;
            }
            catch (Exception exception)
            {
                loggingBroker.LogError($"Error occured at {nameof(AddUser)} please contract developer");
                loggingBroker.LogError(exception);

                return null;
            }
        }

        public List<string> RetrieveAllContacts()
        {
            try
            {
                var users = this.fileBroker.ViewContacts();
                loggingBroker.LogInformation("Contacts successfully retrieved");

                return users;
            }
            catch (Exception exception)
            {
                loggingBroker.LogError($"Error occured at {nameof(RetrieveAllContacts)} please contract developer");

                loggingBroker.LogError(exception);

                return null;
            }
        }

        public string RetrieveContact(string userName)
        {
            try
            {
                var user = this.fileBroker.FindContact(userName);
                loggingBroker.LogInformation("Contact successfully retrieved");

                return user;
            }
            catch (Exception exception)
            {
                loggingBroker.LogError($"Error occured at {nameof(RetrieveAllContacts)} please contract developer");

                loggingBroker.LogError(exception);

                return null;
            }
        }

        public string ModifyContact(string userName, string newPhoneNumber)
        {
            try
            {
                var updatedUser = this.fileBroker.UpdateContact(userName, newPhoneNumber);
                loggingBroker.LogInformation("Contact successfully modified");

                return updatedUser;
            }
            catch (Exception exception)
            {
                loggingBroker.LogError($"Error occured at {nameof(RetrieveAllContacts)} please contract developer");

                loggingBroker.LogError(exception);

                return null;
            }
        }

        public bool RemoveContact(string userName)
        {
            try
            {
                var state = this.fileBroker.DeleteContact(userName);
                loggingBroker.LogInformation("Contact successfully modified");

                return state;
            }
            catch (Exception exception)
            {
                loggingBroker.LogError($"Error occured at {nameof(RetrieveAllContacts)} please contract developer");

                loggingBroker.LogError(exception);

                return false;
            }
        }
    }
}
