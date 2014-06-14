﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }


            MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1), 3);

            engine.AddObject(theBall);

            UnstoppableBall usBall = new UnstoppableBall(new MatrixCoords(15, 2), new MatrixCoords(1, 2));

            engine.AddObject(usBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock wallLeftBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(wallLeftBlock);

                IndestructibleBlock wallRightBlock = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(wallRightBlock);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
