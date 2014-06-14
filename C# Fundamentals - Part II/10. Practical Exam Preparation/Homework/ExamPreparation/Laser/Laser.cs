using System;

namespace Laser
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

    class Laser
    {
        static void Main(string[] args)
        {
            Dimension cubeDimensions = ReadData();
            Dimension laserStartPosition = ReadData();
            laserStartPosition.width -= 1;
            laserStartPosition.height -= 1;
            laserStartPosition.depth -= 1;
            Dimension laserDirection = ReadData();

            Dimension lastVisitedPosition = LaserPath(cubeDimensions, laserStartPosition, laserDirection);
            Console.WriteLine("{0} {1} {2}", lastVisitedPosition.width + 1, lastVisitedPosition.height + 1, lastVisitedPosition.depth + 1);
        }
  
        private static Dimension LaserPath(Dimension cubeDimensions, Dimension laserStartPosition, Dimension laserDirection)
        {
            bool[, ,] visited = new bool[cubeDimensions.width, cubeDimensions.height, cubeDimensions.depth];
           
            Dimension currentPosition = new Dimension(laserStartPosition.width, laserStartPosition.height, laserStartPosition.depth);
            visited[currentPosition.width, currentPosition.height, currentPosition.depth] = true;

            Dimension nextPosition = new Dimension(currentPosition.width, currentPosition.height, currentPosition.depth);

            while (true)
            {
                nextPosition.width += laserDirection.width;
                nextPosition.height += laserDirection.height;
                nextPosition.depth += laserDirection.depth;

                // if next step is in visited cube or is on edge laser stops
                if (visited[nextPosition.width, nextPosition.height, nextPosition.depth] == true ||
                    IsOnEdge(cubeDimensions, nextPosition))
                {
                    break;
                }

                // move a step forward
                currentPosition.width = nextPosition.width;
                currentPosition.height = nextPosition.height;
                currentPosition.depth = nextPosition.depth;

                // mark cube as visited
                visited[currentPosition.width, currentPosition.height, currentPosition.depth] = true;

                // update direction (if a wall is reached - calculate reflection)
                // structs are value types
                laserDirection = UpdateDirection(currentPosition, cubeDimensions, laserDirection);
            }

            return currentPosition;
        }

        private static Dimension UpdateDirection(Dimension currentPosition, Dimension cubeDimensions, Dimension laserDirection)
        {
            if (currentPosition.width == 0 || currentPosition.width == cubeDimensions.width - 1)
            {
                laserDirection.width *= -1;
            }

            if (currentPosition.height == 0 || currentPosition.height == cubeDimensions.height - 1)
            {
                laserDirection.height *= -1;
            }

            if (currentPosition.depth == 0 || currentPosition.depth == cubeDimensions.depth - 1)
            {
                laserDirection.depth *= -1;
            }

            return laserDirection;
        }

        private static bool IsOnEdge(Dimension cubeDimentions, Dimension position)
        {
            // width edges
            if ((position.height == 0 && position.depth == 0) ||
                (position.height == 0 && position.depth == cubeDimentions.depth - 1) || 
                (position.height == cubeDimentions.height - 1 && position.depth == 0) ||
                (position.height == cubeDimentions.height - 1 && position.depth == cubeDimentions.depth - 1))
            {
                return true;
            }

            // height edges
            if ((position.width == 0 && position.depth == 0) ||
                (position.width == 0 && position.depth == cubeDimentions.depth - 1) ||
                (position.width == cubeDimentions.width - 1 && position.depth == 0) ||
                (position.width == cubeDimentions.width - 1 && position.depth == cubeDimentions.depth - 1))
            {
                return true;
            }

            // depth edges
            if ((position.height == 0 && position.width == 0) ||
                (position.height == 0 && position.width == cubeDimentions.width - 1) ||
                (position.height == cubeDimentions.height - 1 && position.width == 0) ||
                (position.height == cubeDimentions.height - 1 && position.width == cubeDimentions.width - 1))
            {
                return true;   
            }

            return false;
        }

        private static Dimension ReadData()
        {
            string dataStr = Console.ReadLine();
            string[] data = dataStr.Split(new char[] { ' ' });

            Dimension dimension = new Dimension(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]));

            return dimension;
        }
    }
}
