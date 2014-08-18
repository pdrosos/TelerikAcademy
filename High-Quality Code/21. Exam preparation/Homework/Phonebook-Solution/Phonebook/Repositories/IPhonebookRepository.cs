namespace Phonebook.Repositories
{
    using System.Collections.Generic;
    using Phonebook.Entities;

    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PhonebookEntry[] ListEntries(int startIndex, int count);
    }
}