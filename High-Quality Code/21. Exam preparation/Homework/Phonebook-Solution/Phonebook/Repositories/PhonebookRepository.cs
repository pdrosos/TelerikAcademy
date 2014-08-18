namespace Phonebook.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Entities;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly OrderedSet<PhonebookEntry> sorted = new OrderedSet<PhonebookEntry>();
        private readonly Dictionary<string, PhonebookEntry> dictionary = new Dictionary<string, PhonebookEntry>();
        private readonly MultiDictionary<string, PhonebookEntry> multidict = new MultiDictionary<string, PhonebookEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> phones)
        {
            string nameToLower = name.ToLowerInvariant();
            PhonebookEntry entry;

            bool isNewEntry = !this.dictionary.TryGetValue(nameToLower, out entry);
            if (isNewEntry)
            {
                entry = new PhonebookEntry();
                entry.Name = name;
                entry.Phones = new SortedSet<string>();
                this.dictionary.Add(nameToLower, entry);

                this.sorted.Add(entry);
            }

            foreach (var phone in phones)
            {
                this.multidict.Add(phone, entry);
            }

            entry.Phones.UnionWith(phones);

            return isNewEntry;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.Phones.Remove(oldent);
                this.multidict.Remove(oldent, entry);

                entry.Phones.Add(newent);
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public PhonebookEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dictionary.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid range");
            }

            PhonebookEntry[] list = new PhonebookEntry[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                PhonebookEntry entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}