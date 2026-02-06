using System;
using System.Windows.Forms;

namespace YourApp
{
    public class SettingsForm : Form
    {
        CheckBox chkAutoUpdate = new CheckBox();

        public SettingsForm()
        {
            Text = "设置";
            Width = 400;
            Height = 200;

            chkAutoUpdate.Text = "启用自动更新（推荐）";
            chkAutoUpdate.Left = 30;
            chkAutoUpdate.Top = 40;
            chkAutoUpdate.CheckedChanged += (_, __) =>
            {
                Properties.Settings.Default.AutoUpdateEnabled = chkAutoUpdate.Checked;
                Properties.Settings.Default.Save();
            };

            Controls.Add(chkAutoUpdate);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MicaHelper.EnableMica(this);
            chkAutoUpdate.Checked = Properties.Settings.Default.AutoUpdateEnabled;
        }
    }
}