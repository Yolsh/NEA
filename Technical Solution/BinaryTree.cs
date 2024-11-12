using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Solution
{
    public class SortNode
    {
        public SortNode Left;
        public SortNode Right;
        public Box b;
        public Point Position;
        public Size Size;

        public SortNode(Size size, Point location)
        {
            this.Size = size;
            Position = location;
        }

        public static void AddBox(Box b, SortNode root)
        {
            if (root.b is null)
            {
                root.b = b;
                root.Left = new SortNode(new Size(root.Size.Width - b.buffer.Size.Width, b.buffer.Size.Height), new Point(root.Position.X + b.buffer.Size.Width, root.Position.Y));
                root.Right = new SortNode(new Size(root.Size.Width, root.Size.Height - b.buffer.Size.Height), new Point(root.Position.X, root.Position.Y + b.buffer.Size.Height));
            }
            else if (b.buffer.Size.Height <= root.Left.Size.Height && b.buffer.Size.Width <= root.Left.Size.Width)
            {
                try
                {
                    AddBox(b, root.Left);
                }
                catch (IncorrectPlacementException)
                {
                    if (b.buffer.Size.Height <= root.Right.Size.Height && b.buffer.Size.Width <= root.Right.Size.Width) AddBox(b, root.Right);
                    else throw new IncorrectPlacementException();
                }
            }
            else if (b.buffer.Size.Height <= root.Right.Size.Height && b.buffer.Size.Width <= root.Right.Size.Width) AddBox(b, root.Right);
            else throw new IncorrectPlacementException();
        }

        public static void CorrectPositions(SortNode root, List<Door> doors)
        {
            if (root.b is null) return;
            CorrectPositions(root.Left, doors);
            CorrectPositions(root.Right, doors);
            root.b.Position = new Point(root.Position.X + root.b.buffer.BufferWidth, root.Position.Y + root.b.buffer.BufferWidth);
            root.b.buffer.Position = root.Position;
            if (root.Left.b != null && !root.DoorCollideY(doors))
            {
                root.b.CollapseRight();
                MoveLeft(root.Left);
            }
            if (root.Right.b != null && !root.DoorCollideX(doors))
            {
                root.b.CollapseBottom();
                MoveUp(root.Right);
            }
            if (root.b.buffer.Position.X == 0 && !root.DoorCollideX(doors))
            {
                root.b.CollapseLeft();
                MoveLeft(root.Left);
            }
            if (root.b.buffer.Position.Y == 0 && !root.DoorCollideY(doors))
            {
                root.b.CollapseTop();
                MoveUp(root.Right);
            }
            return;
        }


        private static void MoveLeft(SortNode ToMove)
        {
            if (ToMove.b == null) return;
            ToMove.b.buffer.Position.X -= ToMove.b.buffer.BufferWidth;
            ToMove.b.Position.X -= ToMove.b.buffer.BufferWidth;
            if (ToMove.Left.b == null) ToMove.b.CollapseLeft();
            if (ToMove.Right.b == null) ToMove.b.CollapseTop();
            MoveLeft(ToMove.Left);
            MoveLeft(ToMove.Right);
        }

        private static void MoveUp(SortNode ToMove)
        {
            if (ToMove.b == null) return;
            ToMove.b.buffer.Position.Y -= ToMove.b.buffer.BufferWidth;
            ToMove.b.Position.Y -= ToMove.b.buffer.BufferWidth;
            if (ToMove.Left.b == null) ToMove.b.CollapseLeft();
            if (ToMove.Right.b == null) ToMove.b.CollapseTop();
            MoveUp(ToMove.Left);
            MoveUp(ToMove.Right);
        }

        private bool DoorCollideX(List<Door> doors)
        {
            bool collideDoor = false;
            foreach (Door door in doors)
            {
                if (door.wall == Door.Wall.Left || door.wall == Door.Wall.Right)
                {
                    if ((door.location.Y > b.Position.Y || door.location.Y < b.Position.Y + b.Size.Height) ||
                    (door.location.Y + door.radius > b.Position.Y || door.location.Y + door.radius < b.Position.Y + b.Size.Height)) collideDoor = true;
                }
            }
            return collideDoor;
        }

        private bool DoorCollideY(List<Door> doors)
        {
            bool collideDoor = false;
            foreach (Door door in doors)
            {
                if (door.wall == Door.Wall.Top || door.wall == Door.Wall.Bottom)
                {
                    if ((door.location.X > b.Position.X || door.location.X < b.Position.X + b.Size.Width) ||
                    (door.location.X + door.radius > b.Position.X || door.location.X + door.radius < b.Position.X + b.Size.Width)) collideDoor = true;
                }
            }
            return collideDoor;
        }
    }
}
