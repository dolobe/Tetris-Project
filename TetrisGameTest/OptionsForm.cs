using System;
using System.Windows.Forms;

public partial class OptionsForm : Form
{
    public OptionsForm()
    {
        this.Text = "Options";
        this.Size = new System.Drawing.Size(400, 300);

        Label messageLabel = new Label
        {
            Text = "Paramètres à personnaliser ici.",
            Location = new System.Drawing.Point(50, 50),
            AutoSize = true
        };
        this.Controls.Add(messageLabel);
    }
}
