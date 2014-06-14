using System;

namespace Tron3D
{
    struct Dimension
    {
        public int width;
        public int height;
        public int depth;

        public Dimension(int width, int height, int depth)
        {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }
    }

    class Tron3D
    {
        static void Main(string[] args)
        {
            Dimension cubeDimensions = ReadCubeDimensions();

            string redPlayerSteps = Console.ReadLine();
            string bluePlayerSteps = Console.ReadLine();

            int redPlayerDistance = 0;
            string winner = PlayGame(cubeDimensions, redPlayerSteps, bluePlayerSteps, out redPlayerDistance);
        }

        private static string PlayGame(Dimension cubeDimensions, string redPlayerSteps, string bluePlayerSteps, out int redPlayerDistance)
        {
            redPlayerDistance = 0;
            string winner = string.Empty;

            Dimension redPlayerStartPosition = new Dimension(cubeDimensions.width / 2 - 1, cubeDimensions.height / 2 - 1, 0);

            Dimension redPlayerCurrentPosition = new Dimension(cubeDimensions.width / 2 - 1, cubeDimensions.height / 2 - 1, 0);
            Dimension bluePlayerCurrentPosition = new Dimension(cubeDimensions.width / 2 - 1, cubeDimensions.height / 2 - 1, cubeDimensions.depth -1);

            //Dimension redPlayerNextPosition = new Dimension(redPlayerCurrentPosition.width, redPlayerCurrentPosition.height, redPlayerCurrentPosition.depth);
            //Dimension bluePlayerNextPosition = new Dimension(bluePlayerCurrentPosition.width, bluePlayerCurrentPosition.height, bluePlayerCurrentPosition.depth);

            Dimension redPlayerDirection = new Dimension(0, 1, 0);
            Dimension bluePlayerDimension = new Dimension(0, 1, 0);

            bool[, ,] redPlayerVisited = new bool[cubeDimensions.width, cubeDimensions.height, cubeDimensions.depth];
            bool[, ,] bluePlayerVisited = new bool[cubeDimensions.width, cubeDimensions.height, cubeDimensions.depth];

            int redCurrentStep = 0;
            int blueCurrentStep = 0;
            while (true)
            {
                // turn red player right
                if (redPlayerSteps[redCurrentStep] == 'R') 
                {
                    redPlayerDirection = TurnRight(cubeDimensions, redPlayerCurrentPosition, redPlayerDirection);
                    redCurrentStep++;
                }

                // turn red player left
                if (redPlayerSteps[redCurrentStep] == 'L')
                {
                    redPlayerDirection = TurnLeft(cubeDimensions, redPlayerCurrentPosition, redPlayerDirection);
                    redCurrentStep++;
                }

                // move red player
                if (redPlayerSteps[redCurrentStep] == 'M')
                {
                    redPlayerCurrentPosition = MovePlayer(redPlayerCurrentPosition, redPlayerDirection, cubeDimensions);
                    redCurrentStep++;
                }

                // collision
                if (bluePlayerVisited[redPlayerCurrentPosition.width, redPlayerCurrentPosition.height, redPlayerCurrentPosition.depth] = true
                    || IsOnForbiddenWall(redPlayerCurrentPosition, cubeDimensions))
                {
                    winner = "BLUE";
                    break;
                }

                                
            }

            redPlayerDistance = 
                Math.Abs(redPlayerStartPosition.width - redPlayerCurrentPosition.width) +
                Math.Abs(redPlayerStartPosition.height - redPlayerCurrentPosition.height) +
                Math.Abs(redPlayerStartPosition.depth - redPlayerCurrentPosition.depth);

            return winner;
        }
  
        private static Dimension MovePlayer(Dimension position, Dimension direction, Dimension cubeDimensions)
        {
            position.width += direction.width;
            position.height += direction.height;
            position.depth += direction.depth;

            if (position.width < 0 || position.width == cubeDimensions.width)
            {
                if (position.width < 0)
                {
                    position.width++;
                }
                if (position.width == cubeDimensions.width)
                {
                    position.width--;
                }
                if (position.depth == 0)
                {
                    position.depth++;
                }
                else
                {
                    position.depth--;
                }
            }

            if (position.depth < 0 || position.depth == cubeDimensions.depth)
            {
                if (position.depth < 0)
                {
                    position.depth++;

                }
                if (position.depth == cubeDimensions.depth)
                {
                    position.depth--;
                }
                if (position.height == 0)
                {
                    position.height++;
                }
                else
                {
                    position.height--;
                }
            }

            if (position.height < 0 || position.height == cubeDimensions.height)
            {
                if (position.height < 0)
                {
                    position.height++;
                }
                if (position.height == cubeDimensions.height)
                {
                    position.height--;
                }
                if (position.depth == 0)
                {
                    position.depth++;
                }
                else
                {
                    position.depth--;
                }
            }

            return position;
        }

        private static Dimension TurnLeft(Dimension cubeDimensions, Dimension currentPosition, Dimension direction)
        {
            if (currentPosition.height == 0 || currentPosition.height == cubeDimensions.height - 1)
            {
                if (direction.width == 0 && direction.depth == 1)
                {
                    direction.width = -1;
                    direction.depth = 0;
                }
                else if (direction.width == -1 && direction.depth == 0)
                {
                    direction.width = 0;
                    direction.depth = -1;
                }
                else if (direction.width == 0 && direction.depth == -1)
                {
                    direction.width = 1;
                    direction.depth = 0;
                }
                else
                {
                    direction.width = 0;
                    direction.depth = 1;
                }
            }
            else if (currentPosition.depth == 0 || currentPosition.depth == cubeDimensions.depth - 1)
            {
                if (direction.width == 0 && direction.height == 1)
                {
                    direction.width = -1;
                    direction.height = 0;
                }
                else if (direction.width == -1 && direction.height == 0)
                {
                    direction.width = 0;
                    direction.height = -1;
                }
                else if (direction.width == 0 && direction.height == -1)
                {
                    direction.width = 1;
                    direction.height = 0;
                }
                else
                {
                    direction.width = 0;
                    direction.height = 1;
                }
            }

            return direction;
        }

        private static Dimension TurnRight(Dimension cubeDimensions, Dimension currentPosition, Dimension direction)
        {
            if (currentPosition.height == 0 || currentPosition.height == cubeDimensions.height - 1)
            {
                if (direction.width == 0 && direction.depth == 1)
                {
                    direction.width = 1;
                    direction.depth = 0;
                }
                else if (direction.width == 1 && direction.depth == 0)
                {
                    direction.width = 0;
                    direction.depth = -1;
                }
                else if (direction.width == 0 && direction.depth == -1)
                {
                    direction.width = -1;
                    direction.depth = 0;
                }
                else
                {
                    direction.width = 0;
                    direction.depth = 1;
                }
            }
            else if (currentPosition.depth == 0 || currentPosition.depth == cubeDimensions.depth - 1)
            {
                if (direction.width == 0 && direction.height == 1)
                {
                    direction.width = 1;
                    direction.height = 0;
                }
                else if (direction.width == 1 && direction.height == 0)
                {
                    direction.width = 0;
                    direction.height = -1;
                }
                else if (direction.width == 0 && direction.height == -1)
                {
                    direction.width = -1;
                    direction.height = 0;
                }
                else
                {
                    direction.width = 0;
                    direction.height = 1;
                }
            }
            
            return direction;
        }

        private static bool IsOnForbiddenWall(Dimension position, Dimension cubeDimensions)
        {
            if (position.width == 0 || position.width == cubeDimensions.width - 1)
            {
                return true;
            }

            return false;
        }

        private static Dimension ReadCubeDimensions()
        {
            string dataStr = Console.ReadLine();
            string[] data = dataStr.Split(new char[] { ' ' });

            Dimension dimension = new Dimension(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));

            return dimension;
        }
    }
}
