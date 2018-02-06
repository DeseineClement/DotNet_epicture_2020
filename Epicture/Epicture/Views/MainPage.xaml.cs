using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Epicture.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private void LogToImgUrOnClicked(object sender, EventArgs e)
	    {
	        SelectHost.IsVisible = false;
	        ImgUrLogin.IsVisible = true;
	    }

	    private void GeTokenOnClicked(object sender, EventArgs e)
	    {
            Device.OpenUri(new Uri("https://api.imgur.com/oauth2/authorize?client_id=f413d0439a121fc&response_type=pin"));
	    }

	    private void ButtonImgurLoginOnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new ShowPage());
	    }
	}
}
