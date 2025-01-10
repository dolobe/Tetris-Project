using System;
using System.Drawing;

namespace TetrisGameTest
{
    public class Grid
    {
        private int rows, cols;
        private Color[,] cells;

        public Grid(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            cells = new Color[rows, cols];
        }

        public bool CanMoveDown(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X;
                int y = block.Y + 1;

                if (y >= rows || x < 0 || x >= cols || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CanMoveLeft(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X - 1;
                int y = block.Y;

                if (x < 0 || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CanMoveRight(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X + 1;
                int y = block.Y;

                if (x >= cols || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CanPlacePiece(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X;
                int y = block.Y;

                if (x < 0 || x >= cols || y < 0 || y >= rows || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        public void Merge(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                cells[block.Y, block.X] = piece.Color;
            }
        }

        public void ClearFullRows(ref int score)
        {
            for (int y = 0; y < rows; y++)
            {
                bool fullRow = true;
                for (int x = 0; x < cols; x++)
                {
                    if (cells[y, x] == Color.Empty)
                    {
                        fullRow = false;
                        break;
                    }
                }

                if (fullRow)
                {
                    score += 100;
                    for (int ty = y; ty > 0; ty--)
                    {
                        for (int tx = 0; tx < cols; tx++)
                        {
                            cells[ty, tx] = cells[ty - 1, tx];
                        }
                    }
                    for (int x = 0; x < cols; x++)
                    {
                        cells[0, x] = Color.Empty;
                    }
                }
            }
        }

        public void Draw(Graphics g, int cellWidth, int cellHeight)
        {
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (cells[y, x] != Color.Empty)
                    {
                        g.FillRectangle(new SolidBrush(cells[y, x]), x * cellWidth, y * cellHeight, cellWidth, cellHeight);
                        g.DrawRectangle(Pens.Black, x * cellWidth, y * cellHeight, cellWidth, cellHeight);
                    }
                }
            }
        }
    }
}

