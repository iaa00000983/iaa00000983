using Squirrel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YourApp
{
    public static class UpdateHelper
    {
        private const string UpdateUrl = "https://github.com/iaa00000983/Baidu_directlink/releases/latest/";

        public static async Task CheckUpdateSilentlyAsync(Form owner)
        {
            try
            {
                using var mgr = new UpdateManager(UpdateUrl);
                var info = await mgr.CheckForUpdate();

                if (info.ReleasesToApply == null || info.ReleasesToApply.Count == 0)
                    return;

                var result = MessageBox.Show(
                    owner,
                    $"发现新版本 {info.FutureReleaseEntry.Version}\n是否立即更新？",
                    "发现更新",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result != DialogResult.Yes)
                    return;

                await mgr.UpdateApp();

                MessageBox.Show(
                    owner,
                    "更新完成，程序将重新启动。",
                    "更新成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                UpdateManager.RestartApp();
            }
            catch
            {
                // silent
            }
        }
    }
}
