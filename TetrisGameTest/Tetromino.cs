using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGameTest
{
    public class Tetromino
    {
        public Point[] Blocks { get; private set; }
        public Color Color { get; private set; }

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

        public Tetromino(Point[] blocks, Color color)
        {
            Blocks = blocks;
            Color = color;
        }

        public static Tetromino GetRandomPiece()
        {
            int index = random.Next(Shapes.Length);
            Point[] shape = (Point[])Shapes[index].Clone();
            Color color = Colors[index];
            return new Tetromino(shape, color);
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
            for (int i = 0; i < Blocks.Length; i++)
            {
                int x = Blocks[i].X;
                Blocks[i].X = Blocks[i].Y;
                Blocks[i].Y = -x;
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var block in Blocks)
            {
                g.FillRectangle(new SolidBrush(Color), block.X * 20, block.Y * 20, 20, 20);
            }
        }

        public void RotateBack()
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                int y = Blocks[i].Y;
                Blocks[i].Y = Blocks[i].X;
                Blocks[i].X = -y;
            }
        }

    }
}
