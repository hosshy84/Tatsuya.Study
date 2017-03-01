using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Slack.Model;
using Xamarin.Slack.ViewModel;

namespace Xamarin.Slack
{
	public partial class UserList : ContentPage
	{
		UsersViewModel viewModel;
		public UserList()
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

			await Navigation.PushAsync(new UserDetail(user, viewModel));

			ListViewUsers.SelectedItem = null;
		}
	}
}
