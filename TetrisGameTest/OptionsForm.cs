using System;
using System.Windows.Forms;

public partial class OptionsForm : Form
{
    private Action<int> onDifficultySelected;

    public OptionsForm(Action<int> onDifficultySelected)
    {
        this.onDifficultySelected = onDifficultySelected;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Text = "Options";
        this.Size = new System.Drawing.Size(400, 300);

        Label levelLabel = new Label
        {
            Text = "Choisissez un niveau:",
            Location = new System.Drawing.Point(50, 100),
            AutoSize = true
        };
        this.Controls.Add(levelLabel);

        RadioButton easyButton = new RadioButton
        {
            Text = "Easy",
            Location = new System.Drawing.Point(50, 130),
            Checked = true
        };
        this.Controls.Add(easyButton);

        RadioButton mediumButton = new RadioButton
        {
            Text = "Medium",
            Location = new System.Drawing.Point(150, 130)
        };
        this.Controls.Add(mediumButton);

        RadioButton hardButton = new RadioButton
        {
            Text = "Hard",
            Location = new System.Drawing.Point(250, 130)
        };
        this.Controls.Add(hardButton);

        Button okButton = new Button
        {
            Text = "OK",
            Location = new System.Drawing.Point(150, 200)
        };
        okButton.Click += (sender, e) =>
        {
            if (easyButton.Checked)
            {
                onDifficultySelected(500);
            }
            else if (mediumButton.Checked)
            {
                onDifficultySelected(300);
            }
            else if (hardButton.Checked)
            {
                onDifficultySelected(150);
            }

            this.Close();
        };
        this.Controls.Add(okButton);
    }
}
