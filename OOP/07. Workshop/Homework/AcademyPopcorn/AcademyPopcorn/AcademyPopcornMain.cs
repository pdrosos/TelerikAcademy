using System;
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

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock;

                // Task 10 - add exploding blocks
                if (i % 2 == 0)
                {
                    currBlock = new ExplodingBlock(new MatrixCoords(startRow + 1, i));
                }
                // Task 12 - add gift block
                else
                {
                    currBlock = new GiftBlock(new MatrixCoords(startRow + 1, i));                    
                }

                engine.AddObject(currBlock);
            }

            // Task 1 - add indestructible blocks
            for (int i = 2; i < WorldRows; i++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(i, 0)));
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1)));
            }
            for (int i = 0; i < WorldCols; i++)
            {
                engine.AddObject(new IndestructibleBlock(new MatrixCoords(2, i)));
            }

            // Task 9 - test the unpassable blocks
            for (int i = 2; i < WorldCols / 3; i += 4)
            {
                engine.AddObject(new UnpassableBlock(new MatrixCoords(startRow + 2, i)));
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            // Task 7 - test the meteorite ball
            //Ball theMeteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theMeteoriteBall);

            // Task 9 - test the unstoppable ball
            //Ball theUnstopableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theUnstopableBall);
            
            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine gameEngine = new Engine(renderer, keyboard, 200);
            // Task 13 - Shooting engine
            ShootingEngine gameEngine = new ShootingEngine(renderer, keyboard, 200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            // Task 13 - Shooting racket
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
