namespace Phonebook.ConsoleCommands.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.ConsoleCommands.Info;
    using Phonebook.Entities;
    using Phonebook.OutputContainers;
    using Phonebook.Repositories;

    public class ListCommand : ICommand
    {
        private IPhonebookRepository repository;

        private IOutputContainer outputContainer;

        public ListCommand(IPhonebookRepository repository, IOutputContainer outputContainer)
        {
            this.repository = repository;
            this.outputContainer = outputContainer;
        }

        public void Execute(CommandInfo commandInfo)
        {
            try
            {
                string startIndex = commandInfo.Arguments.First();
                string itemsCount = commandInfo.Arguments.ElementAt(1);

                int startIndexNumber = int.Parse(startIndex);
                int itemsCountNumber = int.Parse(itemsCount);

                IEnumerable<PhonebookEntry> entries = this.repository.ListEntries(startIndexNumber, itemsCountNumber);
                foreach (var entry in entries)
                {
                    this.outputContainer.AppendLine(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.outputContainer.AppendLine("Invalid range");
            }
        }
    }
}
