using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Menu
{
    public const int width = 70;
    public const int height = 23;
    public static int counter = 0;
    //Side Bar
    static void SideBar()
    {
        for (int i = 0; i <= height + 1; i++)
        {
            Console.SetCursorPosition(width, i);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("|");
        }
        int infoRow = 2;
        Console.SetCursorPosition(width + 1, infoRow++); infoRow++;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("High Scores");
        Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Game One: ");
        Console.ForegroundColor = ConsoleColor.Green;       
        Console.Write(counter);
        Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Game Two: ");
        Console.ForegroundColor = ConsoleColor.Green;        
        Console.Write(counter);
        Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Game Three: ");
        Console.ForegroundColor = ConsoleColor.Green;       
        Console.Write(counter);
        Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Game Four: ");
        Console.ForegroundColor = ConsoleColor.Green;       
        Console.Write(counter);
        Console.SetCursorPosition(width + 2, infoRow++); infoRow++;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Game Five: ");
        Console.ForegroundColor = ConsoleColor.Green;        
        Console.Write(counter);
        Console.SetCursorPosition(width + 1, infoRow++); infoRow++;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Last Played Game: ");
        Console.SetCursorPosition(width + 2, infoRow++); infoRow++;// tuk mozhe da slozhim po nqkakyv nachin eventualno koq e bila igrata
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(counter);// scora i
    }
    //

    //Story
    static void GameStory() {
        Console.SetCursorPosition(20, 1);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Welcome to Felix the Cat Game");
        Console.SetCursorPosition(0, 3);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(new string('+', width));
        Console.SetCursorPosition(17, 5);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Little Felix wants to become a ninja,");
        Console.SetCursorPosition(14, 6);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("but first, he has to go through some trials!");
        Console.SetCursorPosition(25, 7);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Help him make it!");
        Console.SetCursorPosition(23, 8);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Choose your destiny:");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.SetCursorPosition(0, 22);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write(new string('+', width));
    }
    //

    // Game Selection
    static void SelectedGame() 
    {
        Console.SetCursorPosition(22, 10);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("1. Game one.");
        Console.SetCursorPosition(22, 11);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("2. Game two.");
        Console.SetCursorPosition(22, 12);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("3. Game three.");
        Console.SetCursorPosition(22, 13);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("4. Game four.");
        Console.SetCursorPosition(22, 14);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("5. Game five.");
        Console.SetCursorPosition(28, 15);

        byte selectedGame = byte.Parse(Console.ReadLine());

        if (selectedGame > 5 || selectedGame <= 0)
        {
            Console.SetCursorPosition(18, 16);
            Console.WriteLine("We have only five ;)! Try again!");
            selectedGame = byte.Parse(Console.ReadLine());
        }
        else if (selectedGame == 1)
        {
            // call game one
        }
        else if (selectedGame == 2)
        {
            // call game two
        }
        else if (selectedGame == 3)
        {
            // call game three
        }
        else if (selectedGame == 4)
        {
            // call game four
        }
        else if (selectedGame == 5)
        {
            // call game five
        }
    }
    //

    static void Main()
    {
        Console.CursorVisible = false;
        Console.BufferWidth = Console.WindowWidth = 100;
        Console.BufferHeight = Console.WindowHeight = 25;
        GameStory();
        SideBar();
        SelectedGame();        
    }
}
