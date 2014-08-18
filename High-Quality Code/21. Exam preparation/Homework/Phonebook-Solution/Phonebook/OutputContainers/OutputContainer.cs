namespace Phonebook.OutputContainers
{
    using System.Text;
    using Phonebook.OutputContainers.Visitors;

    public class OutputContainer : IOutputContainer
    {
        private readonly StringBuilder output = new StringBuilder();

        public void AppendLine(string text)
        {
            this.output.AppendLine(text);
        }

        public string GetOutput()
        {
            return this.output.ToString();
        }

        public void Accept(IOutputContainerVisitor visitor)
        {
            visitor.Visit(this.output.ToString());
        }
    }
}
