using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;



namespace ChatCLIENT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            MainPage.MinimumHeightRequest = 500;
            MainPage.MinimumWidthRequest = 500;
        }
    }
}
