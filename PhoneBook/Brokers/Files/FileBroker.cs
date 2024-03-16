using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneBook.Brokers.Files
{
    internal class FileBroker : IFileBroker
    {
        private readonly string filePath = "../../../Files/Contacts.txt";

        public FileBroker() =>
            EnsureFileExists(filePath);

        public string CreateContact(string userName, string phoneNumber)
        {
            string contact = $"{userName}: {phoneNumber}";

            File.AppendAllText(filePath, contact + Environment.NewLine);

            return contact;
        }

        public List<string> ViewContacts()
        {
            List<string> contacts = new List<string>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                contacts.Add(line);
            }

            return contacts;
        }

        public string FindContact(string userName)
        {
            string[] contacts = File.ReadAllLines(filePath);

            var foundContactString = contacts
                .FirstOrDefault(contact => contact.StartsWith(userName + ":"));

            return foundContactString;
        }

        public string UpdateContact(string userName, string newPhoneNumber)
        {
            string[] contacts = File.ReadAllLines(filePath);

            int index = Array.FindIndex(
                contacts, contact => contact.StartsWith(userName + ":"));

            if (index != -1)
            {
                contacts[index] = $"{userName}: {newPhoneNumber}";
                File.WriteAllLines(filePath, contacts);

                return contacts[index];
            }
            else
            {
                return null;
            }
        }


        public bool DeleteContact(string userName)
        {
            if (File.Exists(filePath))
            {
                string[] contacts = File.ReadAllLines(filePath);

                var remainingContacts = contacts
                    .Where(contact => !contact.StartsWith(userName + ":")).ToList();

                File.WriteAllLines(filePath, remainingContacts);

                return true;
            }
            else
                return false;
        }

        private void EnsureFileExists(string filePath)
        {
            bool fileExists = File.Exists(filePath);

            if (fileExists is false)
            {
                File.Create(filePath).Close();
            }
        }
    }
}
