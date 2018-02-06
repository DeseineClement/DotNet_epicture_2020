using Epicture.ImgurAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Epicture.BaseAPI;

namespace Epicture.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            this.Appearing += MainPage_Appearing;
		}

        private async void MainPage_Appearing(object sender, EventArgs e)
        {
            ImgurAuthenticator test = new ImgurAuthenticator("8e0148d95c9866b", "46eba94c9f31b5b053a9f2aa2cb289845a454b7e");
            AuthenticationResultBase result = await test.Authenticate("71c4dadff2");

            if (result.Success)
            {
                AAPIClient client = result.APIClient;

                PicturesResult pics = await client.Search("cats", BaseAPI.Enums.FILE_TYPE.ALL, BaseAPI.Enums.SORT_TYPE.VIRAL);
                PicturesResult homePics = await client.FetchHomeImages();
                Console.WriteLine();
            }
        }
    }
}
