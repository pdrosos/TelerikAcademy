using System;
using System.Collections.Generic;

namespace Slides
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
    };

    class Slides
    {
        static Dictionary<string, Dimension> slidesDirections = new Dictionary<string, Dimension>()
        {
            {"L", new Dimension(-1, 1, 0)},
            {"R", new Dimension(1, 1, 0)},
            {"F", new Dimension(0, 1, -1)},
            {"B", new Dimension(0, 1, 1)},
            {"FL", new Dimension(-1, 1, -1)},
            {"FR", new Dimension(1, 1, -1)},
            {"BL", new Dimension(-1, 1, 1)},
            {"BR", new Dimension(1, 1, 1)},
        };

        static void Main(string[] args)
        {
            Dimension cubeDimensions = ReadCubeDimensions();
            string[, ,] cube = ReadCube(cubeDimensions);
            Dimension ballStartPosition = ReadBallStartPosition();

            string canExit = string.Empty;
            Dimension lastVisitedPosition = BallPath(cube, ballStartPosition, out canExit);
            Console.WriteLine(canExit);
            Console.WriteLine("{0} {1} {2}", lastVisitedPosition.width, lastVisitedPosition.height, lastVisitedPosition.depth);
        }

        private static Dimension BallPath(string[, ,] cube, Dimension ballStartPosition, out string canExit)
        {
            Dimension currentPosition = new Dimension(ballStartPosition.width, ballStartPosition.height, ballStartPosition.depth);
            string cubeElement = string.Empty;

            while (true)
            {
                cubeElement = cube[currentPosition.width, currentPosition.height, currentPosition.depth];
                string command = cubeElement.Substring(0, 1);

                if (command == "S")
                {
                    string[] commandElements = cubeElement.Split(new char[] { ' ' });
                    Dimension direction = slidesDirections[commandElements[1]];
                    
                    if (currentPosition.height + direction.height == cube.GetLength(1))
                    {
                        canExit = "Yes";
                        return currentPosition;
                    }
                    else if (currentPosition.width + direction.width < 0 ||
                        currentPosition.width + direction.width == cube.GetLength(0))
                    {
                        canExit = "No";
                        return currentPosition;
                    }
                    else if (currentPosition.depth + direction.depth < 0 ||
                        currentPosition.depth + direction.depth == cube.GetLength(2))
                    {
                        canExit = "No";
                        return currentPosition;
                    }
                    else
                    {
                        currentPosition.width += direction.width;
                        currentPosition.height += direction.height;
                        currentPosition.depth += direction.depth;
                    }
                }
                else if (command == "T")
                {
                    string[] commandElements = cubeElement.Split(new char[] { ' ' });
                    currentPosition.width = int.Parse(commandElements[1]);
                    currentPosition.depth = int.Parse(commandElements[2]);
                }
                else if (command == "E")
                {
                    if (currentPosition.height + 1 == cube.GetLength(1))
                    {
                        canExit = "Yes";
                        return currentPosition;
                    }
                    else
                    {
                        currentPosition.height += 1;
                    }
                }
                else if (command == "B")
                {
                    canExit = "No";
                    return currentPosition;
                }
            }
        }

        private static Dimension ReadCubeDimensions()
        {
            string dataStr = Console.ReadLine();
            string[] data = dataStr.Split(new char[] { ' ' });

            Dimension dimension = new Dimension(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));

            return dimension;
        }

        private static Dimension ReadBallStartPosition()
        {
            string dataStr = Console.ReadLine();
            string[] data = dataStr.Split(new char[] { ' ' });

            Dimension dimension = new Dimension(int.Parse(data[0]), 0, int.Parse(data[1]));

            return dimension;
        }

        private static string[, ,] ReadCube(Dimension cubeDimensions)
        {
            string[, ,] cube = new string[cubeDimensions.width, cubeDimensions.height, cubeDimensions.depth];

            for (int height = 0; height < cubeDimensions.height; height++)
            {
                string layerStr = Console.ReadLine();
                string[] layer = layerStr.Split(new string[] { " | " }, StringSplitOptions.None);
                for (int depth = 0; depth < layer.Length; depth++)
                {
                    string[] layerElements = layer[depth].Split(new string[] {"(", ")", ")("}, StringSplitOptions.RemoveEmptyEntries);
                    for (int width = 0; width < layerElements.Length; width++)
                    {
                        cube[width, height, depth] = layerElements[width];
                    }
                }
            }

            return cube;
        }
    }
}
