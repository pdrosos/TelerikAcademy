namespace Phonebook.ConsoleCommands.Sanitizers
{
    public interface IPhoneSanitizer
    {
        string Sanitize(string phone);
    }
}
