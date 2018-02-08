using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
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
        private ObservableCollection<PictureResult> SearchedPictures;

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
                SearchedPictures =  new ObservableCollection<PictureResult>(homePics.Result);
                GridViewAlbum.ItemsSource = SearchedPictures;
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

            var images = (GridViewAlbum.ItemsSource as ObservableCollection<PictureResult>);
            PicturesResult searchPics = await Client.Search(search, type, sort, size);

            UpdateGridViewAlbum(searchPics);
        }

        private void UpdateGridViewAlbum(PicturesResult searchPics)
        {
            GridViewAlbum.SelectedItems.OfType<PicturesResult>().ToList().Clear();
            SearchedPictures.Clear();

            if (searchPics.Success)
            {
                searchPics.Result.ForEach(pic => SearchedPictures.Add(pic));
            }
        }

        private async void AddFavoriteButtonOnClick(object sender, RoutedEventArgs e)
        {
            var selectedItems = GridViewAlbum.SelectedItems.OfType<PictureResult>().ToList();
            if (selectedItems.Count == 0)
            {
                var errorDialog = new MessageDialog("You must chose pictures to add in favorites");
                await errorDialog.ShowAsync();
                return;
            } 
            //TODO: call api to add to favorites;
            var dialog = new MessageDialog("Pictures successfully added to favorites");
            await dialog.ShowAsync();
        }

        private async void RemoveFavoriteButtonOnClick(object sender, RoutedEventArgs e)
        {
            var selectedItems = GridViewAlbum.SelectedItems.OfType<PictureResult>().ToList();
            if (selectedItems.Count == 0)
            {
                var errorDialog = new MessageDialog("You must chose pictures to add in favorites");
                await errorDialog.ShowAsync();
                return;
            }
            //TODO: call api to add to favorites;
            var dialog = new MessageDialog("Pictures successfully added to favorites");
            await dialog.ShowAsync();
        }

        private async void HomeButtonOnClick(object sender, RoutedEventArgs e)
        {
            PicturesResult homePics = await Client.FetchHomeImages();
            if (homePics.Success)
            {
                UpdateGridViewAlbum(homePics);
                searchPanel.Visibility = Visibility.Visible;
                addFavoriteButton.Visibility = Visibility.Visible;

                removeFavoriteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void FavoriteButtonOnClick(object sender, RoutedEventArgs e)
        {
            //todo get favorite from api
            searchPanel.Visibility = Visibility.Collapsed;
            addFavoriteButton.Visibility = Visibility.Collapsed;

            removeFavoriteButton.Visibility = Visibility.Visible;
        }
    }
}
