using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using WinRT;
using System.Windows.Forms;

namespace YourApp
{
    public static class MicaHelper
    {
        public static void EnableMica(Form form)
        {
            if (!MicaController.IsSupported())
                return;

            var hwnd = form.Handle;
            var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            var controller = new MicaController
            {
                Kind = MicaKind.BaseAlt
            };

            var config = new SystemBackdropConfiguration
            {
                Theme = SystemBackdropTheme.Dark,
                IsInputActive = true
            };

            controller.AddSystemBackdropTarget(appWindow);
            controller.SetSystemBackdropConfiguration(config);
        }
    }
}