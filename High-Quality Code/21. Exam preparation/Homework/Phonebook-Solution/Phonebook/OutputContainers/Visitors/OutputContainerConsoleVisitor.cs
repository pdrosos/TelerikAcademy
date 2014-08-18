namespace Phonebook.OutputContainers.Visitors
{
    using System;

    public class OutputContainerConsoleVisitor : IOutputContainerVisitor
    {
        public void Visit(string output)
        {
            Console.Write(output);
        }
    }
}
