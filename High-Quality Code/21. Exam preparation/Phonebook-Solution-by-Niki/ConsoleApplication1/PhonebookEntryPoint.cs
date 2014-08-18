namespace Phonebook
{
    using System;
    using System.Linq;

    using Phonebook.Command;

    // TODO: Check for StyleCop warnings
    // TODO: Fix runtime error
    public static class PhonebookEntryPoint
    {
        internal static void Main()
        {
            IDeletablePhonebookRepository data = new PhonebookRepositoryWithDictionary();
            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitizer = new PhonebookSanitizer();
            ICommandFactory commandFactory = new CommandFactoryWithLazyLoading(data, printer, sanitizer);
            ICommandParser commandParser = new CommandParser();

            while (true)
            {
                string userLine = Console.ReadLine();

                if (userLine == "End" || userLine == null)
                {
                    break;
                }

                var commandInfo = commandParser.Parse(userLine);
                IPhonebookCommand command = commandFactory.CreateCommand(commandInfo.CommandName, commandInfo.Arguments.Count());
                command.Execute(commandInfo.Arguments.ToArray());
            }

            printer.Accept(new ConsolePrinterVisitorWithNewLine());
        }
    }
}