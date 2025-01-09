namespace TetrisGameTest
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel ScorePanel;
        private System.Windows.Forms.Panel NextPanel;

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label scoreLabel;
        private void InitializeComponent()
        {
            this.ScorePanel = new System.Windows.Forms.Panel();
            this.NextPanel = new System.Windows.Forms.Panel();

            this.gamePanel = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // ScorePanel
            this.ScorePanel.BackColor = System.Drawing.Color.Black;
            this.ScorePanel.Location = new System.Drawing.Point(5, 50);
            this.ScorePanel.Size = new System.Drawing.Size(200, 200);

            // NextPanel
            this.NextPanel.BackColor = System.Drawing.Color.Black;
            this.NextPanel.Location = new System.Drawing.Point(795, 50);
            this.NextPanel.Size = new System.Drawing.Size(200, 200);
            this.NextPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NextPanel_Paint);

            // gamePanel Je touche plus a ça
            this.gamePanel.BackColor = System.Drawing.Color.Black;
            this.gamePanel.Location = new System.Drawing.Point(225, 50);
            this.gamePanel.Size = new System.Drawing.Size(550, 900);
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);

            // scoreLabel Je touche plus 
            this.scoreLabel.Location = new System.Drawing.Point(550, 50);
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.Font = new System.Drawing.Font("Arial", 16F);

            //  Je touche plus 
            this.ClientSize = new System.Drawing.Size(1000, 1300);
            this.Controls.Add(this.ScorePanel);
            this.Controls.Add(this.NextPanel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.scoreLabel);
            this.Text = "Tetris Game";
            this.ResumeLayout(false);
        }
    }
}

