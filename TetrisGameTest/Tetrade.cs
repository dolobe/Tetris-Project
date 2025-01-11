using System;
using System.Drawing;

namespace TetrisGameTest
{
    public class Tetrade
    {
        public Point[] Blocks { get; private set; }
        public Color Color { get; private set; }
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        private static Random random = new Random();

        private static readonly Point[][] Shapes = new Point[][]
        {
            new Point[] { new Point(0, 0), new Point(1, 0), new Point(0, 1), new Point(1, 1) }, // Carré
            new Point[] { new Point(0, 1), new Point(1, 1), new Point(2, 1), new Point(3, 1) }, // Ligne
            new Point[] { new Point(0, 1), new Point(1, 0), new Point(1, 1), new Point(1, 2) }, // T
            new Point[] { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(2, 1) }, // Z
            new Point[] { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(2, 0) }  // S
        };

        private static readonly Color[] Colors = new Color[]
        {
            Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Cyan
        };

        public Tetrade(Point[] blocks, Color color)
        {
            Blocks = blocks;
            Color = color;
        }

        public static Tetrade GetRandomPiece()
        {
            int index = random.Next(Shapes.Length);
            Point[] shape = (Point[])Shapes[index].Clone();
            Color color = Colors[index];
            return new Tetrade(shape, color);
        }

        public void MoveDown()
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].Y += 1;
            }
        }

        public void MoveLeft()
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].X -= 1;
            }
        }

        public void MoveRight()
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i].X += 1;
            }
        }

        public void Rotate()
        {
            Point pivot = Blocks[1];
            Point[] newBlocks = new Point[Blocks.Length];

            for (int i = 0; i < Blocks.Length; i++)
            {
                int x = Blocks[i].X - pivot.X;
                int y = Blocks[i].Y - pivot.Y;
                newBlocks[i] = new Point(pivot.X - y, pivot.Y + x);
            }

            if (CanPlacePiece(new Tetrade(newBlocks, this.Color)))
            {
                Blocks = newBlocks;
            }
        }


        public void RotateBack()
        {
            Point pivot = Blocks[1];
            for (int i = 0; i < Blocks.Length; i++)
            {
                int x = Blocks[i].X - pivot.X;
                int y = Blocks[i].Y - pivot.Y;
                Blocks[i].X = pivot.X + y;
                Blocks[i].Y = pivot.Y - x;
            }
        }

        public bool CanPlacePiece(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                if (block.X < 0 || block.X >= 10 || block.Y < 0 || block.Y >= 20)
                    return false;
            }
            return true;
        }

        public void Draw(Graphics g, int cellWidth, int cellHeight, int offsetX = 0, int offsetY = 0)
        {
            Brush pieceBrush = new SolidBrush(Color);

            foreach (Point block in Blocks)
            {
                int x = block.X * cellWidth + offsetX;
                int y = block.Y * cellHeight + offsetY;
                g.FillRectangle(pieceBrush, x, y, cellWidth, cellHeight);

                g.DrawRectangle(Pens.Black, x, y, cellWidth, cellHeight);
            }
        }

    }
}
