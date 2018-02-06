using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Epicture.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LogToImgUrOnClicked(object sender, RoutedEventArgs e)
        {
            SelectHost.Visibility = Visibility.Collapsed;
            ImgUrLogin.Visibility = Visibility.Visible;
        }

        private void ButtonImgurLoginOnClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShowPage));
        }

        private async void GeTokenOnClicked(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://api.imgur.com/oauth2/authorize?client_id=f413d0439a121fc&response_type=pin"));

        }
    }
}
