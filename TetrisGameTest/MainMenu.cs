using System;
using System.Windows.Forms;
using TetrisGameTest;

public partial class MainMenu : Form
{
    public MainMenu()
    {
        InitializeMenu();
    }

    private void InitializeMenu()
    {
        this.Text = "Tetris - Menu Principal";
        this.Size = new System.Drawing.Size(400, 300);

        Button playButton = new Button
        {
            Text = "Play",
            Location = new System.Drawing.Point(150, 50),
            Size = new System.Drawing.Size(100, 40)
        };
        playButton.Click += PlayButton_Click;

        Button optionsButton = new Button
        {
            Text = "Options",
            Location = new System.Drawing.Point(150, 120),
            Size = new System.Drawing.Size(100, 40)
        };
        optionsButton.Click += OptionsButton_Click;

        Button quitButton = new Button
        {
            Text = "Quit",
            Location = new System.Drawing.Point(150, 190),
            Size = new System.Drawing.Size(100, 40)
        };
        quitButton.Click += QuitButton_Click;

        this.Controls.Add(playButton);
        this.Controls.Add(optionsButton);
        this.Controls.Add(quitButton);
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
        Form1 gameForm = new Form1();
        gameForm.Show();
        this.Hide();
    }

    private void OptionsButton_Click(object sender, EventArgs e)
    {
        OptionsForm optionsForm = new OptionsForm();
        optionsForm.ShowDialog();
    }

    private void QuitButton_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
