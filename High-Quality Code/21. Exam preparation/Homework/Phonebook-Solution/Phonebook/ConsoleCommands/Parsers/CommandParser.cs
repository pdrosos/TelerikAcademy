namespace Phonebook.ConsoleCommands.Parsers
{
    using System;
    using Phonebook.ConsoleCommands.Info;

    internal class CommandParser : ICommandParser
    {
        public CommandInfo Parse(string commandText)
        {
            int firstParenthesisPosition = commandText.IndexOf('(');
            if (firstParenthesisPosition == -1)
            {
                throw new ArgumentException("Invalid command");
            }
            
            if (!commandText.EndsWith(")"))
            {
                throw new ArgumentException("Invalid command");
            }

            string commandName = commandText.Substring(0, firstParenthesisPosition);

            string argumentsText = commandText.Substring(firstParenthesisPosition + 1, commandText.Length - firstParenthesisPosition - 2);

            string[] arguments = argumentsText.Split(',');
            for (int j = 0; j < arguments.Length; j++)
            {
                arguments[j] = arguments[j].Trim();
            }

            CommandInfo commandInfo = new CommandInfo();
            commandInfo.CommandName = commandName;
            commandInfo.Arguments = arguments;

            return commandInfo;
        }
    }
}
