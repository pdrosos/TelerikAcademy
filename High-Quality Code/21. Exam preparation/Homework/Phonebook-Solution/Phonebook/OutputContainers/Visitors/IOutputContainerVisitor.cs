namespace Phonebook.OutputContainers.Visitors
{
    public interface IOutputContainerVisitor
    {
        void Visit(string currentText);
    }
}
