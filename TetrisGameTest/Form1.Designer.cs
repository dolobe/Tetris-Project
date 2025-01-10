namespace TetrisGameTest
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Panel nextPanel;
        private System.Windows.Forms.Panel gamePanel;

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label topScoreLabel;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Initialisation des panels
            this.scorePanel = new System.Windows.Forms.Panel();
            this.nextPanel = new System.Windows.Forms.Panel();
            this.gamePanel = new System.Windows.Forms.Panel();

            // Initialisation des labels
            this.scoreLabel = new System.Windows.Forms.Label();
            this.topScoreLabel = new System.Windows.Forms.Label();

            // SuspendLayout pour éviter les redessins multiples pendant l'initialisation
            this.SuspendLayout();

            // Configuration du panel score
            this.scorePanel.Location = new System.Drawing.Point(10, 50);
            this.scorePanel.Size = new System.Drawing.Size(200, 200);
            this.scorePanel.BackColor = System.Drawing.Color.Black;

            // Configuration du label score
            this.scoreLabel.Location = new System.Drawing.Point(15, 50);
            this.scoreLabel.Size = new System.Drawing.Size(180, 20);
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scorePanel.Controls.Add(this.scoreLabel);

            // Configuration du label top score
            this.topScoreLabel.Location = new System.Drawing.Point(15, 140);
            this.topScoreLabel.Size = new System.Drawing.Size(180, 20);
            this.topScoreLabel.Text = "Top Score: 0";
            this.topScoreLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.topScoreLabel.ForeColor = System.Drawing.Color.White;
            this.scorePanel.Controls.Add(this.topScoreLabel);

            // Configuration du panel next (prochaine pièce)
            this.nextPanel.Location = new System.Drawing.Point(790, 50);
            this.nextPanel.Size = new System.Drawing.Size(200, 200);
            this.nextPanel.BackColor = System.Drawing.Color.Black;
            this.nextPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NextPanel_Paint);

            // Configuration du panel jeu
            this.gamePanel.BackColor = System.Drawing.Color.Black;
            this.gamePanel.Location = new System.Drawing.Point(225, 50);
            this.gamePanel.Size = new System.Drawing.Size(550, 900);
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);

            // Configuration de la fenêtre principale
            this.ClientSize = new System.Drawing.Size(1000, 1300);
            this.Controls.Add(this.scorePanel);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.gamePanel);
            this.Text = "Tetris Game";

            // ResumeLayout pour rétablir la disposition
            this.ResumeLayout(false);
        }
    }
}
