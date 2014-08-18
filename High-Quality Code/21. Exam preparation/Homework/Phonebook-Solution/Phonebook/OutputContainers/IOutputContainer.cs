namespace Phonebook.OutputContainers
{
    using Phonebook.OutputContainers.Visitors;

    public interface IOutputContainer
    {
        void AppendLine(string text);

        string GetOutput();

        void Accept(IOutputContainerVisitor visitor);
    }
}
