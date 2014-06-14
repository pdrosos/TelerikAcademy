using System;

namespace FelixTheCat.BlackHole
{
    /// <summary>
    /// Generate black hole object
    /// </summary>
    class BlackHoleGenerator
    {
        /// <summary>
        /// Black hole's shape
        /// </summary>
        /// <returns></returns>
        public static string[,] GetBlackHoleSymbols()
        {
            string[,] symbols = 
            {
                {"░░▒▒▓▓███████████████████████████████████████████████████████████████████████████████▓▓▒▒░░"},
                {"  ░░▒▒▓▓███████████████████████████████████████████████████████████████████████████▓▓▒▒░░  "},
                {"    ░░▒▒▓▓███████████████████████████████████████████████████████████████████████▓▓▒▒░░    "},
                {"      ░░▒▒▓▓███████████████████████████████████████████████████████████████████▓▓▒▒░░      "},
              //{"        ░░▒▒▓▓███████████████████████████████████████████████████████████████▓▓▒▒░░        "},
            };

            return symbols;
        }

        /// <summary>
        /// Create a new black hole object
        /// </summary>
        /// <param name="windowHeight"></param>
        /// <param name="windowWidth"></param>
        /// <returns></returns>
        public static BlackHole GenerateBlackHole(int windowHeight, int windowWidth)
        {
            ConsoleColor color = ConsoleColor.DarkRed;
            BlackHole blackHole = new BlackHole(GetBlackHoleSymbols(), color, 0, 0);

            int startX = (windowWidth - blackHole.Width) / 2;
            int startY = (windowHeight - blackHole.Height) / 2;

            blackHole.StartX = startX;
            blackHole.StartY = startY;

            return blackHole;
        }
    }
}
