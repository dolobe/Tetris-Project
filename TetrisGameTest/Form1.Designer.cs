namespace TetrisGameTest
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button quitButton;

        private void InitializeComponent()
        {
            this.gamePanel = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // gamePanel
            this.gamePanel.BackColor = System.Drawing.Color.Black;
            this.gamePanel.Location = new System.Drawing.Point(20, 20);
            this.gamePanel.Size = new System.Drawing.Size(300, 600);
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);


            // scoreLabel
            this.scoreLabel.Location = new System.Drawing.Point(350, 50);
            this.scoreLabel.Text = "Score: 0";
            this.scoreLabel.Font = new System.Drawing.Font("Arial", 16F);

            // playButton
            this.playButton.Location = new System.Drawing.Point(350, 100);
            this.playButton.Text = "Play";
            this.playButton.Click += new System.EventHandler(this.PlayButton_Click);

            // optionsButton
            this.optionsButton.Location = new System.Drawing.Point(350, 150);
            this.optionsButton.Text = "Options";
            this.optionsButton.Click += new System.EventHandler(this.OptionsButton_Click);

            // quitButton
            this.quitButton.Location = new System.Drawing.Point(350, 200);
            this.quitButton.Text = "Quit";
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(500, 650);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.quitButton);
            this.Text = "Tetris Game";
            this.ResumeLayout(false);
        }
    }
}

