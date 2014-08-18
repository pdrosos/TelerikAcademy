namespace Phonebook.ConsoleCommands.Commands
{
    using System.Linq;
    using Phonebook.ConsoleCommands.Info;
    using Phonebook.ConsoleCommands.Sanitizers;
    using Phonebook.OutputContainers;
    using Phonebook.Repositories;

    public class AddPhoneCommand : ICommand
    {
        private IPhonebookRepository repository;

        private IPhoneSanitizer phoneSanitizer;

        private IOutputContainer outputContainer;
        
        public AddPhoneCommand(IPhonebookRepository repository, IPhoneSanitizer phoneSanitizer, IOutputContainer outputContainer)
        {
            this.repository = repository;
            this.phoneSanitizer = phoneSanitizer;
            this.outputContainer = outputContainer;
        }

        public void Execute(CommandInfo commandInfo)
        {
            string name = commandInfo.Arguments.First();
            var phones = commandInfo.Arguments.Skip(1).ToList();
            for (int i = 0; i < phones.Count; i++)
            {
                phones[i] = this.phoneSanitizer.Sanitize(phones[i]);
            }

            bool isNewEntry = this.repository.AddPhone(name, phones);
            if (isNewEntry)
            {
                this.outputContainer.AppendLine("Phone entry created");
            }
            else
            {
                this.outputContainer.AppendLine("Phone entry merged");
            }
        }
    }
}
