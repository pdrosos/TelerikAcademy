using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace FelixTheCat.BlackHole
{
    public static class FiguresGenerator
    {        
        private static readonly List<string[,]> symbols = new List<string[,]>();
        private static readonly List<ConsoleColor> colors = new List<ConsoleColor>();

        private static readonly int distance = 6;

        private static readonly Random randomGenerator = new Random();

        public static List<string[,]> GetSymbols()
        {
            if (symbols.Count > 0)
            {
                return symbols;
            }

            string[,] triangle = 
            {
                {"    █    "},
                {"   ███   "},
                {"  █▓ ██  "},
                {" █▓   ██ "},
                {"█████████"},
            };
            symbols.Add(triangle);

            string[,] reversedTriangle =
            {
                {"█████████"},
                {" ██   ▓█ "},
                {"  ██ ▓█  "},
                {"   ███   "},
                {"    █    "},
            };
            symbols.Add(reversedTriangle);

            string[,] squareWithDot =
            {
                {"░███████░"},
                {"██     ██"},
                {"██ ▒█▒ ██"},
                {"██     ██"},
                {"░███████░"},
            };
            symbols.Add(squareWithDot);

            string[,] square = 
            { 
                {"▒███████▒"},
                {"██     ██"},
                {"██     ██"},
                {"██     ██"},
                {"▒███████▒"},
            };
            symbols.Add(square);

            string[,] hexagon = 
            {
                {"  █████  "},
                {" ██   ▓█ "},
                {"██     ▓█"},
                {" ██   ▓█ "},
                {"  █████  "},
            };
            symbols.Add(hexagon);

            string[,] heart =
            {
                {" ██▓  ██▓ "},
                {"██  █▓  █▓"},
                {" ██    █▓ "},
                {"  ██  █▓  "},
                {"    ██    "},
            };
            symbols.Add(heart);

            string[,] trapezoid =
            {
                {"   ███   "}, 
                {"  █▓ ██  "}, 
                {" █▓   ██ "}, 
                {"█▓     ██"}, 
                {"█████████"},
            };
            symbols.Add(trapezoid);

            return symbols;
        }

        public static List<ConsoleColor> GetColors()
        {
            if (colors.Count > 0)
            {
                return colors;
            }

            colors.Add(ConsoleColor.Blue);
            colors.Add(ConsoleColor.Cyan);
            colors.Add(ConsoleColor.DarkBlue);
            colors.Add(ConsoleColor.DarkCyan);
            colors.Add(ConsoleColor.DarkGreen);
            colors.Add(ConsoleColor.DarkMagenta);
            colors.Add(ConsoleColor.DarkYellow);
            colors.Add(ConsoleColor.Green);
            colors.Add(ConsoleColor.Magenta);
            colors.Add(ConsoleColor.Red);
            colors.Add(ConsoleColor.Yellow);

            return colors;
        }

        public static List<Figure> GetRandomList(int number, int windowWidth)
        {
            GetSymbols();
            GetColors();

            if (number < 1 || number > symbols.Count)
            {
                throw new Exception("Number must be between 1 and " + symbols.Count);
            }

            List<Figure> list = new List<Figure>(number);

            Shuffle(symbols);
            Shuffle(colors);
            
            for (int i = 0; i < number; i++)
            {
                list.Add(new Figure(symbols[i], colors[i], 0, 0));
            }

            CalculateXCoodrinates(ref list, windowWidth);

            return list;
        }

        public static Figure RemoveRandomFigureFromList(ref List<Figure> list, int windowWidth)
        {
            Figure figure = list[randomGenerator.Next(0, list.Count)];
            list.Remove(figure);

            // recalculate x coordinates
            CalculateXCoodrinates(ref list, windowWidth);

            return figure;
        }

        public static List<Figure> GetResultList(List<Figure> originalList, Figure missingElement, int windowWidth)
        {
            List<Figure> resultList = originalList.ToList();
            resultList.Add(missingElement);
            
            Figure newElement;
            do
            {
                newElement = GetRandomFigure();
            } while (resultList.Contains(newElement) == true);

            resultList.Add(newElement);
            Shuffle(resultList);

            CalculateXCoodrinates(ref resultList, windowWidth);

            return resultList;
        }

        public static Figure GetRandomFigure()
        {
            GetSymbols();
            GetColors();

            return new Figure(symbols[randomGenerator.Next(0, symbols.Count)], 
                colors[randomGenerator.Next(0, colors.Count)], 0, 0);
        }

        private static void CalculateXCoodrinates(ref List<Figure> list, int windowWidth)
        {
            int figuresWidth = 0;
            for (int i = 0; i < list.Count; i++)
            {
                figuresWidth += list[i].Width;
            }

            int startX = (windowWidth - (figuresWidth + (distance * (list.Count - 1)))) / 2;
            for (int i = 0; i < list.Count; i++)
            {
                list[i].StartX = startX;
                startX += list[i].Width + distance;
            }
        }

        private static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
