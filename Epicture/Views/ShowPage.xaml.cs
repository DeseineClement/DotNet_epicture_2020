using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Epicture.ImgurAPI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Epicture.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowPage : Page
    {
        private AAPIClient Client;

        public ShowPage()
        {
            InitializeComponent();

            var list = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                list.Add("");
            }

            GridViewAlbum.ItemsSource = list;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
           Client = e.Parameter as AAPIClient;

           PicturesResult homePics = await Client.FetchHomeImages();
            
            if (homePics.Success)
            {
                GridViewAlbum.ItemsSource = new ObservableCollection<PictureResult>(homePics.Result);
            }
        }

        private async void SearchButtonOnClick(object sender, RoutedEventArgs e)
        {
            var search = searchBox.Text;
            var sort = sortBox.SelectionBoxItem as string;
            var type = typeBox.SelectionBoxItem as string;
            var size = sizeBox.SelectionBoxItem as string;

            if (String.IsNullOrEmpty(search))
            {
                var dialog = new MessageDialog("You must enter a query.");
                await dialog.ShowAsync();
                return;
            }

            (GridViewAlbum.ItemsSource as ObservableCollection<PictureResult>).Clear();
            PicturesResult searchPics = await Client.Search(search, type, sort, size);

            if (searchPics.Success)
            {
                searchPics.Result.ForEach(pic => (GridViewAlbum.ItemsSource as ObservableCollection<PictureResult>).Add(pic));
            }
        }
    }
}
