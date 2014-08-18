namespace Phonebook.ConsoleCommands.Commands
{
    using Phonebook.ConsoleCommands.Info;

    public interface ICommand
    {
        void Execute(CommandInfo commandInfo);
    }
}
