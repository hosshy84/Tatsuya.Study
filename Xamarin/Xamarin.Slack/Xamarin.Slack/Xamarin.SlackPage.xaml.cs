using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Slack.Model;
using Xamarin.Slack.ViewModel;

namespace Xamarin.Slack
{
	public partial class Xamarin_SlackPage : ContentPage
	{
		UsersViewModel viewModel;
		public Xamarin_SlackPage()
		{
			InitializeComponent();

			viewModel = new UsersViewModel();
			BindingContext = viewModel;

			ListViewUsers.ItemSelected += ListViewUsers_ItemSelected;
		}

		async void ListViewUsers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var user = e.SelectedItem as User;
			if (user == null) return;

			ListViewUsers.SelectedItem = null;
		}
	}
}
