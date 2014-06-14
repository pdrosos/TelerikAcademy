using System;
using System.Collections.Generic;

namespace KukataIsDancing
{
    struct Dimension
    {
        public int width;
        public int depth;

        public Dimension(int width, int depth)
        {
            this.width = width;
            this.depth = depth;
        }
    }

    class KukataIsDancing
    {
        static void Main(string[] args)
        {
            int numberOfSteps = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfSteps; i++)
            {
                string color = DanceLastPositionColor(Console.ReadLine());
                Console.WriteLine(color);
            }
        }

        private static string DanceLastPositionColor(string danceSteps)
        {
            int squareSide = 3;

            Dimension currentPosition = new Dimension(1, 1);
            Dimension currentDirection = new Dimension(1, 0);            
            foreach (char currentStep in danceSteps)
            {
                if (currentStep == 'L' || currentStep == 'R')
                {
                    currentDirection = UpdateDirection(currentDirection, currentStep);
                }
                else if (currentStep == 'W')
                {
                    currentPosition.width += currentDirection.width;
                    if (currentPosition.width < 0)
                    {
                        currentPosition.width = squareSide - 1;
                    }
                    if (currentPosition.width == squareSide)
                    {
                        currentPosition.width = 0;
                    }

                    currentPosition.depth += currentDirection.depth;
                    if (currentPosition.depth < 0)
                    {
                        currentPosition.depth = squareSide - 1;
                    }
                    if (currentPosition.depth == squareSide)
                    {
                        currentPosition.depth = 0;
                    }
                }
            }

            if (IsVertex(currentPosition, squareSide))
            {
                return "RED";
            }
            else if (IsMiddlePosition(currentPosition, squareSide))
            {
                return "GREEN";
            }
            
            return "BLUE";
        }

        private static Dimension UpdateDirection(Dimension direction, char step)
        {
            if (step == 'L')
            {
                return UpdateDirectionLeft(direction);
            }
            else
            {
                return UpdateDirectionRight(direction);
            }
        }

        private static Dimension UpdateDirectionRight(Dimension direction)
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

            return direction;
        }

        private static Dimension UpdateDirectionLeft(Dimension direction)
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

            return direction;
        }

        static bool IsVertex(Dimension position, int squareSide)
        {
            if ((position.width == 0 && position.depth == 0) ||
                (position.width == 0 && position.depth == squareSide - 1) ||
                (position.width == squareSide - 1 && position.depth == 0) ||
                (position.width == squareSide - 1 && position.depth == squareSide - 1)) 
            {
                return true;
            }

            return false;
        }

        static bool IsMiddlePosition(Dimension position, int squareSide)
        {
            if (position.width == squareSide / 2 && position.depth == squareSide / 2)
            {
                return true;
            }

            return false;
        }
    }
}
