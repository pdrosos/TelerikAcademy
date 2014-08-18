namespace Computers.Commands.Parsers
{
    using Computers.Commands.Info;

    public interface ICommandParser
    {
        CommandInfo Parse(string commandText);
    }
}
