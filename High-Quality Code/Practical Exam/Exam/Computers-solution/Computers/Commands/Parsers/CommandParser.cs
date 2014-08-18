namespace Computers.Commands.Parsers
{
    using System;
    using Computers.Commands.Info;

    internal class CommandParser : ICommandParser
    {
        public CommandInfo Parse(string commandText)
        {
            var parsedCommand = commandText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parsedCommand.Length != 2)
            {
                {
                    throw new ArgumentException("Invalid command!");
                }
            }

            var commandName = parsedCommand[0];
            var argument = int.Parse(parsedCommand[1]);

            CommandInfo commandInfo = new CommandInfo();
            commandInfo.CommandName = commandName;
            commandInfo.Argument = argument;

            return commandInfo;            
        }
    }
}
