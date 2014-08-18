namespace Phonebook.ConsoleCommands.Factories
{
    using System;
    using System.Linq;
    using Phonebook.ConsoleCommands.Commands;
    using Phonebook.ConsoleCommands.Info;    
    using Phonebook.ConsoleCommands.Sanitizers;
    using Phonebook.OutputContainers;
    using Phonebook.Repositories;

    public class CommandFactory : ICommandFactory
    {
        private IPhonebookRepository repository;

        private IPhoneSanitizer phoneSanitizer;

        private IOutputContainer outputContainer;

        private AddPhoneCommand addPhoneCommand;

        private ChangePhoneCommand changePhoneCommand;

        private ListCommand listCommand;

        public CommandFactory(IPhonebookRepository repository, IPhoneSanitizer phoneSanitizer, IOutputContainer outputContainer)
        {
            this.repository = repository;
            this.phoneSanitizer = phoneSanitizer;
            this.outputContainer = outputContainer;
        }

        public ICommand CreateCommand(CommandInfo commandInfo)
        {
            if (commandInfo.CommandName.StartsWith("AddPhone") && (commandInfo.Arguments.Count() >= 2))
            {
                return this.GetAddPhoneCommand();
            }
            else if ((commandInfo.CommandName == "ChangePhone") && (commandInfo.Arguments.Count() == 2))
            {
                return this.GetChangePhoneCommand();
            }
            else if ((commandInfo.CommandName == "List") && (commandInfo.Arguments.Count() == 2))
            {
                return this.GetListCommand();
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }
        }

        protected AddPhoneCommand GetAddPhoneCommand()
        {
            if (this.addPhoneCommand == null)
            {
                this.addPhoneCommand = new AddPhoneCommand(this.repository, this.phoneSanitizer, this.outputContainer);
            }

            return this.addPhoneCommand;
        }

        protected ChangePhoneCommand GetChangePhoneCommand()
        {
            if (this.changePhoneCommand == null)
            {
                this.changePhoneCommand = new ChangePhoneCommand(this.repository, this.phoneSanitizer, this.outputContainer);
            }

            return this.changePhoneCommand;
        }

        protected ListCommand GetListCommand()
        {
            if (this.listCommand == null)
            {
                this.listCommand = new ListCommand(this.repository, this.outputContainer);
            }

            return this.listCommand;
        }
    }
}
