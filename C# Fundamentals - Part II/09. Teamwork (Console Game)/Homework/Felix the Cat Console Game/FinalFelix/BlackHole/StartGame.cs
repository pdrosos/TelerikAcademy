using System;

namespace FelixTheCat.BlackHole
{
    /// <summary>
    /// Game's entry point
    /// </summary>
    class StartGame
    {
        static void Main(string[] args)
        {
            Game blackHoleGame = new Game();
            blackHoleGame.Play();
        }
    }
}
