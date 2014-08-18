namespace Decorator
{
    public class DecoratorDemo
    {
        public static void Main(string[] args)
        {
            // Wraps the original Console.WriteLine() and add functionality to
            // support colors.
            ColorConsole.WriteLine("Decorator Demo.", System.ConsoleColor.Yellow);
            ColorConsole.WriteLine("No color.");
            ColorConsole.WriteLine("Color example.", System.ConsoleColor.Green);
            ColorConsole.WriteLine("Yet another example.", System.ConsoleColor.Red);
        }
    }
}
