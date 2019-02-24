using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenSaver
{
    public static class DirectionHelper
    {
        public enum Direction { Left, Right, Up, Down };        

        private static Direction CreateRandomDirection() => (Direction)new Random().Next(0, 4);

        public static Direction GetNewDirection(Control control, Direction direction)
        {
            if (isCentered(control))
                direction = CreateRandomDirection();

            if (isLimitOfScreenReached(control, direction))
                direction = GetOpositeDirection(direction);

            return direction;
        }

        public static Direction GetOpositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Left;
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                default:
                    throw new Exception("Not a known direction.");
            }
        }

        private static bool isCentered(Control control) => control.Location.X == 0 && control.Location.Y == 0;

        private static bool isLimitOfScreenReached(Control control, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return control.Location.X < -control.Width;
                case Direction.Right:
                    return control.Location.X > control.Width;
                case Direction.Up:
                    return control.Location.Y < -control.Height;
                case Direction.Down:
                    return control.Location.Y > control.Height;
                default:
                    return true;
            }
        }

        public static Point GetPointBasedOnDirectionAndDisplacement(Direction direction, int displacement)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Point(-displacement, 0);
                case Direction.Right:
                    return new Point(displacement, 0);
                case Direction.Up:
                    return new Point(0, -displacement);
                case Direction.Down:
                    return new Point(0, displacement);
                default:
                    return new Point(0, 0);
            }
        }        

    }
}
