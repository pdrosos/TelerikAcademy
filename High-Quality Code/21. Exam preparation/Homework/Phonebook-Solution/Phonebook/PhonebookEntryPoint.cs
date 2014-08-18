namespace Phonebook
{
    using System;
    using Phonebook.ConsoleCommands.Commands;
    using Phonebook.ConsoleCommands.Factories;
    using Phonebook.ConsoleCommands.Info;
    using Phonebook.ConsoleCommands.Parsers;
    using Phonebook.ConsoleCommands.Sanitizers;
    using Phonebook.OutputContainers;
    using Phonebook.OutputContainers.Visitors;
    using Phonebook.Repositories;

    internal class PhonebookEntryPoint
    {
        private static void Main()
        {
            ICommandParser parser = new CommandParser();

            IPhonebookRepository repository = new PhonebookRepository();
            IPhoneSanitizer phoneSanitizer = new PhoneSanitizer();
            IOutputContainer outputContainer = new OutputContainer();

            ICommandFactory commandFactory = new CommandFactory(repository, phoneSanitizer, outputContainer);

            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "End" || userInput == null)
                {
                    // Error reading from console 
                    break;
                }

                CommandInfo commandInfo = parser.Parse(userInput);
                ICommand command = commandFactory.CreateCommand(commandInfo);
                command.Execute(commandInfo);
            }
            
            outputContainer.Accept(new OutputContainerConsoleVisitor());
        }
    }
}