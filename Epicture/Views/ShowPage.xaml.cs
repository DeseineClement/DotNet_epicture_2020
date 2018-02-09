using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
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
        private ObservableCollection<dynamic> WaitingPictures;

        public ShowPage()
        {
            InitializeComponent();

            SearchedPictures = new ObservableCollection<PictureResult>();
            WaitingPictures = new ObservableCollection<dynamic>();

            GridViewAlbum.ItemsSource = SearchedPictures;
            WaitingListView.ItemsSource = WaitingPictures;
        }

        private void LockNavigation()
        {
            homeButton.IsEnabled = false;
            userButton.IsEnabled = false;
            favoriteButton.IsEnabled = false;
            uploadButton.IsEnabled = false;
        }

        private void UnlockNavigation()
        {
            homeButton.IsEnabled = true;
            userButton.IsEnabled = true;
            favoriteButton.IsEnabled = true;
            uploadButton.IsEnabled = true;
        }

        private void AddWaitingPicture(Symbol icon, string message)
        {
            WaitingPictures.Add(new
            {
                Icon = icon,
                Message = String.IsNullOrEmpty(message) 
                    ? "Untitled" 
                    : message.Length <= 20 
                        ? message 
                        : message.Substring(0, 17) + "..."
            });
            WaitingListView.Visibility = Visibility.Visible;
        }

        private void RemoveWaitingPicture(Symbol icon, string message)
        {
            WaitingPictures.Remove(new
            {
                Icon = icon,
                Message = String.IsNullOrEmpty(message)
                    ? "Untitled"
                    : message.Length <= 20
                        ? message
                        : message.Substring(0, 17) + "..."
            });

            if (WaitingPictures.Count == 0)
                WaitingListView.Visibility = Visibility.Collapsed;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            Client = e.Parameter as AAPIClient;
            ShowCommandBar.Content = "Welcome " + Client.UserName + " !";

            PicturesResult homePics = await Client.FetchHomeImages();

            UpdateGridViewAlbum(homePics);
            Client.FileUploading += (sender, s) => AddWaitingPicture(Symbol.Upload, s.File.Name);
            Client.FileUploaded += (sender, s) => RemoveWaitingPicture(Symbol.Upload, s.File.Name);

            Client.UserFileDeleting += (sender, s) => AddWaitingPicture(Symbol.Delete, s.Name);
            Client.UserFileDeleted += (sender, s) => RemoveWaitingPicture(Symbol.Delete, s.Name);

            Client.FavoriteAdding += (sender, s) => AddWaitingPicture(Symbol.Favorite, s.Name);
            Client.FavoriteAdded += (sender, s) => RemoveWaitingPicture(Symbol.Favorite, s.Name);
            UnlockNavigation();
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

            LockNavigation();
            PicturesResult searchPics = await Client.Search(search, type, sort, size);
         
            UpdateGridViewAlbum(searchPics);
            UnlockNavigation();
        }

        private void UpdateGridViewAlbum(PicturesResult searchPics)
        {
            GridViewAlbum.SelectedItems.OfType<PicturesResult>().ToList().Clear();
            SearchedPictures.Clear();

            if (searchPics.Success)
                searchPics.Result.ForEach(pic => SearchedPictures.Add(pic));
        }

        private void AddFavoriteButtonOnClick(object sender, RoutedEventArgs e)
        {
            var selectedItems = GridViewAlbum.SelectedItems.OfType<PictureResult>().ToList();
            if (selectedItems.Count == 0)
                return;
            selectedItems.ForEach(pic => Client.AddImageToFavorite(pic));
        }

        private async void HomeButtonOnClick(object sender, RoutedEventArgs e)
        {
            PicturesResult homePics = await Client.FetchHomeImages();
            if (homePics.Success)
            {
                UpdateGridViewAlbum(homePics);

                searchPanel.Visibility = Visibility.Visible;
                addFavoriteButton.Visibility = Visibility.Visible;

                removeUserPictureButton.Visibility = Visibility.Collapsed;

                uploadButtonSubmit.Visibility = Visibility.Collapsed;
                uploadButtonAdd.Visibility = Visibility.Collapsed;

                GridViewAlbum.ItemTemplate = Resources["PictureResultShowTemplate"] as DataTemplate;
                GridViewAlbum.SelectionMode = ListViewSelectionMode.Multiple;
            }
        }

        private async void FavoriteButtonOnClick(object sender, RoutedEventArgs e)
        {
            LockNavigation();
            PicturesResult favoritePics = await Client.FetchFavoriteImages();
            if (favoritePics.Success)
            {
                UpdateGridViewAlbum(favoritePics);

                searchPanel.Visibility = Visibility.Collapsed;
                addFavoriteButton.Visibility = Visibility.Collapsed;

                removeUserPictureButton.Visibility = Visibility.Collapsed;

                uploadButtonSubmit.Visibility = Visibility.Collapsed;
                uploadButtonAdd.Visibility = Visibility.Collapsed;

                GridViewAlbum.ItemTemplate = Resources["PictureResultShowTemplate"] as DataTemplate;
                GridViewAlbum.SelectionMode = ListViewSelectionMode.None;
            }
            UnlockNavigation();
        }

        private async void UserButtonOnClick(object sender, RoutedEventArgs e)
        {
            LockNavigation();
            PicturesResult userPics = await Client.FetchUserImages();
            if (userPics.Success)
            {
                UpdateGridViewAlbum(userPics);

                searchPanel.Visibility = Visibility.Collapsed;
                addFavoriteButton.Visibility = Visibility.Collapsed;

                removeUserPictureButton.Visibility = Visibility.Visible;

                uploadButtonSubmit.Visibility = Visibility.Collapsed;
                uploadButtonAdd.Visibility = Visibility.Collapsed;

                GridViewAlbum.ItemTemplate = Resources["PictureResultShowTemplate"] as DataTemplate;
                GridViewAlbum.SelectionMode = ListViewSelectionMode.Multiple;
            }
            UnlockNavigation();
        }
        private void UploadButtonOnClick(object sender, RoutedEventArgs e)
        {
            LockNavigation();
            SearchedPictures.Clear();

            searchPanel.Visibility = Visibility.Collapsed;
            addFavoriteButton.Visibility = Visibility.Collapsed;

            removeUserPictureButton.Visibility = Visibility.Collapsed;

            uploadButtonSubmit.Visibility = Visibility.Visible;
            uploadButtonAdd.Visibility = Visibility.Visible;

            GridViewAlbum.ItemTemplate = Resources["PictureResultEditTemplate"] as DataTemplate;
            GridViewAlbum.SelectionMode = ListViewSelectionMode.None;
            UnlockNavigation();
        }

        private void RemoveUserPictureButtonOnClick(object sender, RoutedEventArgs e)
        {

            var selectedItems = GridViewAlbum.SelectedItems.OfType<PictureResult>().ToList();
            if (selectedItems.Count == 0)
                return;

            LockNavigation();
            selectedItems.ForEach(async pic =>
            {
                await Client.RemoveUserImage(pic);
                SearchedPictures.Remove(pic);
            });
            UnlockNavigation();
        }

        private void UploadButtonSubmitOnClick(object sender, RoutedEventArgs e)
        {
            if (SearchedPictures.Count == 0)
                return;

            LockNavigation();

            SearchedPictures.OfType<LocalPictureResult>().ToList().ForEach(async pic => await Client.AddUserImage(pic));
            SearchedPictures.Clear();
            UnlockNavigation();
        }

        private async void UploadButtonOnAddClick(object sender, RoutedEventArgs e)
        {
            LockNavigation();
            FileOpenPicker browser = new FileOpenPicker();
            browser.FileTypeFilter.Add(".png");
            browser.FileTypeFilter.Add(".jpg");
            browser.FileTypeFilter.Add(".jpeg");
            IReadOnlyList<StorageFile> files = await browser.PickMultipleFilesAsync();

            files.ToList().ForEach(file =>
            {
                var localPicture = new LocalPictureResult()
                {
                    File = file,
                    Url = file.Path,
                    Description = "",
                    Name = "",
                    Id = ""
                };

                SearchedPictures.Add(localPicture);
            });
            UnlockNavigation();
        }
    }
}
