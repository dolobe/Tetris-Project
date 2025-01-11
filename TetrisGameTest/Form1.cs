using System;
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
        private Tetrade nextPiece;
        private int topScore;
        private const string scoreFilePath = "topscore.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            gameGrid = new Grid(20, 10);
            currentPiece = Tetrade.GetRandomPiece();
            nextPiece = Tetrade.GetRandomPiece();
            gameTimer = new Timer
            {
                Interval = 500
            };
            gameTimer.Tick += GameTimer_Tick;

            LoadTopScore();

            this.KeyDown += Form1_KeyDown;
            gameTimer.Start();

        }


        private void LoadTopScore()
        {
            if (System.IO.File.Exists(scoreFilePath))
            {
                string scoreText = System.IO.File.ReadAllText(scoreFilePath);
                if (int.TryParse(scoreText, out int savedTopScore))
                {
                    topScore = savedTopScore;
                }
            }
            else
            {
                topScore = 0;
            }
            UpdateScoreLabel();
        }

        private void SaveTopScore()
        {
            System.IO.File.WriteAllText(scoreFilePath, topScore.ToString());
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

                currentPiece = nextPiece;
                nextPiece = Tetrade.GetRandomPiece();

                if (!gameGrid.CanPlacePiece(currentPiece))
                {
                    gameTimer.Stop();
                    MessageBox.Show($"Game Over! Votre score : {score}\nTop Score : {topScore}");
                }
            }

            gamePanel.Invalidate();
            nextPanel.Invalidate();
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
            if (score > topScore)
            {
                topScore = score;
                SaveTopScore();
            }

            scoreLabel.Text = $"Score: {score}";
            topScoreLabel.Text = $"Top Score: {topScore}";
        }

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawGrid(g);
            currentPiece.Draw(g, 55, 45);
            gameGrid.Draw(g, 55, 45);
        }

        private void NextPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            int cols = 6;
            int rows = 6;
            int cellWidth = 40;
            int cellHeight = 40;

            Pen gridPen = new Pen(Color.Gray, 1);
            for (int i = 0; i <= rows; i++)
            {
                g.DrawLine(gridPen, 0, i * cellHeight, cols * cellWidth, i * cellHeight);
            }
            for (int j = 0; j <= cols; j++)
            {
                g.DrawLine(gridPen, j * cellWidth, 0, j * cellWidth, rows * cellHeight);
            }

            if (nextPiece != null)
            {
                int panelWidth = nextPanel.Width;
                int panelHeight = nextPanel.Height;

                int pieceWidth = nextPiece.Width * cellWidth;
                int pieceHeight = nextPiece.Height * cellHeight;

                int offsetX = (panelWidth - pieceWidth) / 5;
                int offsetY = (panelHeight - pieceHeight) / 5;

                offsetX = Math.Max(0, offsetX);
                offsetY = Math.Max(0, offsetY);

                nextPiece.Draw(g, cellWidth, cellHeight, offsetX, offsetY);
            }
        }
    }
}
