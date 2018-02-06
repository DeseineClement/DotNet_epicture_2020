using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Epicture.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowPage : Page
    {
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
    }
}
