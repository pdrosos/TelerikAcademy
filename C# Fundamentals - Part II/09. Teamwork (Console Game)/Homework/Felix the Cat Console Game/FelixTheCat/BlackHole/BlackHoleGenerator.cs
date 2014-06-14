using System;

namespace FelixTheCat.BlackHole
{
    class BlackHoleGenerator
    {
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
