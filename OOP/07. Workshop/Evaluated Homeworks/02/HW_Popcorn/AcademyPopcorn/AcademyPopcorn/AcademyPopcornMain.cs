using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 29;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;
            for (int j = startRow; j <= 6; j = j + 3)
            {
                for (int i = startCol; i < endCol; i++)
                {
                    Block currBlock = new Block(new MatrixCoords(j, i));

                    engine.AddObject(currBlock);
                }
            }

            // task 6, 7 and 8 - meteorite ball - symbol M and unstopable ball - symbol U
            Ball ball01 = new Ball(new MatrixCoords(15, 10), new MatrixCoords(-1, 1));
            engine.AddObject(ball01);
            Ball ball02 = new MeteoriteBall(new MatrixCoords(15, 10), new MatrixCoords(-1, -1));
            engine.AddObject(ball02);
            Ball theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 5, WorldCols / 2 - 10), RacketLength);
            engine.AddObject(theRacket);

            // Task 3 - test AddRocket method  - there should alwais be only one racket
            Racket theRacket1 = new Racket(new MatrixCoords(WorldRows - 3, WorldCols / 2), RacketLength);
            engine.AddObject(theRacket1);

            // Task 1 - create sides walls and ceiling of the game - task1
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock leftwall = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(leftwall);
            }

            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock righttwall = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(righttwall);
            }

            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(0, i));
                engine.AddObject(ceiling);
            }


            //Task 8 - unpassable blocks - symbol @
            for (int i = 6; i < 14; i++)
            {
                UnpassableBlock unpasBlock01 = new UnpassableBlock(new MatrixCoords(4, i));
                engine.AddObject(unpasBlock01);
            }

            // Task 5 - Trail object - symbol T
            TrailObject trobj1 = new TrailObject(new MatrixCoords(9, 12), 500);
            engine.AddObject(trobj1);

            //Task 10 - Exploding blocks - simbol E
            Block explod01 = new ExplodingBlock(new MatrixCoords(4, 22));
            engine.AddObject(explod01);

            Block explod02 = new ExplodingBlock(new MatrixCoords(5, 8));
            engine.AddObject(explod02);
            Block explod03 = new ExplodingBlock(new MatrixCoords(5, 12));
            engine.AddObject(explod03);
            Block explod04 = new ExplodingBlock(new MatrixCoords(5, 13));
            engine.AddObject(explod04);
            Block explod05 = new ExplodingBlock(new MatrixCoords(5, 14));
            engine.AddObject(explod05);

            //Task11-12 - Gift block and gift
            Block gift01 = new GiftBlock(new MatrixCoords(5, 29));
            engine.AddObject(gift01);

            Block gift02 = new GiftBlock(new MatrixCoords(5, 16));
            engine.AddObject(gift02);

            //To clear later - floor - to test easier the game
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock floor = new IndestructibleBlock(new MatrixCoords(WorldRows - 1, i));
                engine.AddObject(floor);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard, 100); // Task 2 - in order to set the sleepTime must use the new constructor set in task2

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            //I added this event handler
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
