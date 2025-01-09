﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisGameTest
{
    public partial class Form1 : Form
    {
        private Timer gameTimer;
        private int score;
        private Grid gameGrid;
        private Tetrade currentPiece;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            gameGrid = new Grid(20, 10);
            currentPiece = Tetrade.GetRandomPiece();
            gameTimer = new Timer();
            gameTimer.Interval = 500;
            gameTimer.Tick += GameTimer_Tick;

            this.KeyDown += Form1_KeyDown;
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameGrid.CanMoveDown(currentPiece))
            {
                currentPiece.MoveDown();
            }
            else
            {
                gameGrid.Merge(currentPiece);
                gameGrid.ClearFullRows(ref score);
                UpdateScoreLabel();
                currentPiece = Tetrade.GetRandomPiece();

                if (!gameGrid.CanPlacePiece(currentPiece))
                {
                    gameTimer.Stop();
                    MessageBox.Show($"Game Over! Votre score : {score}");
                }
            }
            gamePanel.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameTimer.Enabled)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (gameGrid.CanMoveLeft(currentPiece)) currentPiece.MoveLeft();
                        break;
                    case Keys.Right:
                        if (gameGrid.CanMoveRight(currentPiece)) currentPiece.MoveRight();
                        break;
                    case Keys.Down:
                        if (gameGrid.CanMoveDown(currentPiece)) currentPiece.MoveDown();
                        break;
                    case Keys.Up:
                        currentPiece.Rotate();
                        if (!gameGrid.CanPlacePiece(currentPiece)) currentPiece.RotateBack();
                        break;
                }
                gamePanel.Invalidate();
            }
        }

        private void DrawGrid(Graphics g)
        {
            int cols = 10;
            int rows = 20;
            int cellWidth = 55;
            int cellHeight = 45;

            Pen gridPen = new Pen(Color.Gray, 1);

            for (int i = 0; i <= rows; i++)
            {
                g.DrawLine(gridPen, 0, i * cellHeight, cols * cellWidth, i * cellHeight);
            }

            for (int j = 0; j <= cols; j++)
            {
                g.DrawLine(gridPen, j * cellWidth, 0, j * cellWidth, rows * cellHeight);
            }
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawGrid(g);
            currentPiece.Draw(g, 55, 45);
            gameGrid.Draw(g, 55, 45);
        }

        private void NextPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            int cellSize = 20;
            System.Drawing.Graphics g = e.Graphics;
            System.Drawing.Pen gridPen = new System.Drawing.Pen(System.Drawing.Color.Gray);

            for (int x = 0; x <= this.nextPanel.Width; x += cellSize)
            {
                g.DrawLine(gridPen, x, 0, x, this.nextPanel.Height);
            }

            for (int y = 0; y <= this.nextPanel.Height; y += cellSize)
            {
                g.DrawLine(gridPen, 0, y, this.nextPanel.Width, y);
            }

            gridPen.Dispose();
        }

    }
}
