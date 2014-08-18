namespace Phonebook.ConsoleCommands.Parsers
{
    using Phonebook.ConsoleCommands.Info;

    public interface ICommandParser
    {
        CommandInfo Parse(string commandText);
    }
}
