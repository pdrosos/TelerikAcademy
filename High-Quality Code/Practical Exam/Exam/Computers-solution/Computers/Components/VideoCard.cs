namespace Computers.Components
{
    using System;

    public class VideoCard
    {
        public VideoCard()
        {
        }

        public bool IsMonochrome { get; set; }

        public void Draw(string a)
        {
            if (this.IsMonochrome)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(a);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(a);
                Console.ResetColor();
            }
        }
    }
}