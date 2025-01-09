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

        // Vérifie si la tétrade peut se déplacer vers le bas sans sortir du grid
        public bool CanMoveDown(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X;
                int y = block.Y + 1;

                // Vérifiez que le bloc reste dans les limites du grid et que la cellule est vide
                if (y >= rows || x < 0 || x >= cols || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        // Vérifie si la tétrade peut se déplacer vers la gauche
        public bool CanMoveLeft(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X - 1;
                int y = block.Y;

                // Vérifiez que le bloc reste dans les limites du grid et que la cellule est vide
                if (x < 0 || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        // Vérifie si la tétrade peut se déplacer vers la droite
        public bool CanMoveRight(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X + 1;
                int y = block.Y;

                // Vérifiez que le bloc reste dans les limites du grid et que la cellule est vide
                if (x >= cols || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        // Vérifie si la tétrade peut être placée dans le grid sans sortir
        public bool CanPlacePiece(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                int x = block.X;
                int y = block.Y;

                // Vérifie si le bloc est en dehors des limites du grid ou si la cellule est déjà occupée
                if (x < 0 || x >= cols || y < 0 || y >= rows || cells[y, x] != Color.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        // Fusionne la tétrade dans le grid
        public void Merge(Tetrade piece)
        {
            foreach (var block in piece.Blocks)
            {
                cells[block.Y, block.X] = piece.Color;
            }
        }

        // Efface les lignes pleines et met à jour le score
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

        // Dessine le grid
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

