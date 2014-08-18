namespace Phonebook.ConsoleCommands.Commands
{
    using System.Linq;
    using Phonebook.ConsoleCommands.Info;
    using Phonebook.ConsoleCommands.Sanitizers;
    using Phonebook.OutputContainers;
    using Phonebook.Repositories;

    public class ChangePhoneCommand : ICommand
    {
        private IPhonebookRepository repository;

        private IPhoneSanitizer phoneSanitizer;

        private IOutputContainer outputContainer;

        public ChangePhoneCommand(IPhonebookRepository repository, IPhoneSanitizer phoneSanitizer, IOutputContainer outputContainer)
        {
            this.repository = repository;
            this.phoneSanitizer = phoneSanitizer;
            this.outputContainer = outputContainer;
        }

        public void Execute(CommandInfo commandInfo)
        {
            string oldPhone = commandInfo.Arguments.First();
            string newPhone = commandInfo.Arguments.ElementAt(1);

            oldPhone = this.phoneSanitizer.Sanitize(oldPhone);
            newPhone = this.phoneSanitizer.Sanitize(newPhone);

            int phonesChangedNumber = this.repository.ChangePhone(oldPhone, newPhone);

            this.outputContainer.AppendLine(string.Format("{0} numbers changed", phonesChangedNumber));
        }
    }
}
