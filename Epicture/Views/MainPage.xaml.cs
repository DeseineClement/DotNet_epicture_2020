using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Epicture.BaseAPI;
using Epicture.ImgurAPI;
using Epicture.ImgurAPI.API;

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

        private async void ButtonImgurLoginOnClicked(object sender, RoutedEventArgs e)
        {
            ImgurAuthenticator authenticator = new ImgurAuthenticator("f413d0439a121fc", "cb4801c6adec9918573c4161c660660cb9e34e02");

            AuthenticationResultBase authenticationResult = await authenticator.Authenticate(PinTextBox.Text);

            if (authenticationResult.Success)
            {
                Frame.Navigate(typeof(ShowPage), authenticationResult.APIClient);
            }
        }

        private async void GeTokenOnClicked(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://api.imgur.com/oauth2/authorize?client_id=f413d0439a121fc&response_type=pin"));

        }
    }
}
