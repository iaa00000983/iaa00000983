using System;
using System.Windows.Forms;

namespace YourApp
{
    public class MainForm : Form
    {
        Button btnSettings = new Button();

        public MainForm()
        {
            Text = "YourApp";
            Width = 900;
            Height = 600;

            btnSettings.Text = "设置";
            btnSettings.Left = 20;
            btnSettings.Top = 20;
            btnSettings.Click += (s, e) =>
            {
                new SettingsForm().ShowDialog(this);
            };

            Controls.Add(btnSettings);
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            MicaHelper.EnableMica(this);

            if (Properties.Settings.Default.AutoUpdateEnabled)
            {
                await UpdateHelper.CheckUpdateSilentlyAsync(this);
            }
        }
    }
}