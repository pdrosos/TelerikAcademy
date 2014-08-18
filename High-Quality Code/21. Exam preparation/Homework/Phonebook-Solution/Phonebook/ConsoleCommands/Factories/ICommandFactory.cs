namespace Phonebook.ConsoleCommands.Factories
{
    using Phonebook.ConsoleCommands.Commands;
    using Phonebook.ConsoleCommands.Info;

    public interface ICommandFactory
    {
        ICommand CreateCommand(CommandInfo commandInfo);
    }
}
