namespace TetrisGameTest
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel scorePanel;
        private System.Windows.Forms.Panel nextPanel;


        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label topScoreLabel;

        private System.Windows.Forms.Panel gamePanel;
        private void InitializeComponent()
        {
            this.scorePanel = new System.Windows.Forms.Panel();
            this.nextPanel = new System.Windows.Forms.Panel();

            this.gamePanel = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.nextPanel.Location = new System.Drawing.Point(220, 10);
            this.nextPanel.Size = new System.Drawing.Size(80, 80);


            this.scorePanel.Location = new System.Drawing.Point(220, 100);
            this.scorePanel.Size = new System.Drawing.Size(80, 100);

            this.scoreLabel.Location = new System.Drawing.Point(10, 10);
            this.scoreLabel.Size = new System.Drawing.Size(60, 20);
            this.scoreLabel.Text = "Score: 0";
            this.scorePanel.Controls.Add(this.scoreLabel);

            this.topScoreLabel.Location = new System.Drawing.Point(10, 40);
            this.topScoreLabel.Size = new System.Drawing.Size(60, 20);
            this.topScoreLabel.Text = "Top: 0";
            this.scorePanel.Controls.Add(this.topScoreLabel);


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
            this.Controls.Add(this.scorePanel);
            this.Controls.Add(this.nextPanel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.scoreLabel);
            this.Text = "Tetris Game";
            this.ResumeLayout(false);
        }
    }
}

