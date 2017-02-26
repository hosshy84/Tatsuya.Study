using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Slack.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Xamarin.Slack.ViewModel
{
	public class UsersViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<User> Users { get; set; }
		public Command GetUsersCommand { get; set; }
		const string token = "";

		public UsersViewModel()
		{
			Users = new ObservableCollection<User>();
			GetUsersCommand = new Command(async () => await GetUsers(), () => !IsBusy);
		}

		void OnPropertyChanged([CallerMemberName] string name = null) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set
			{
				isBusy = value;
				OnPropertyChanged();
				GetUsersCommand.ChangeCanExecute();
			}
		}

		async Task GetUsers()
		{
			if (isBusy) return;

			Exception error = null;
			try
			{
				isBusy = true;

				using (var client = new HttpClient())
				{
					var json = await client.GetStringAsync($"https://slack.com/api/users.list?token={token}");
					var definition = new { members = new List<User>() };
					var items = JsonConvert.DeserializeAnonymousType(json, definition);

					Users.Clear();
					foreach (var item in items.members)
					{
						Users.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error: {ex}");
				error = ex;
			}
			finally
			{
				isBusy = false;
			}

			if (error != null)
				await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
		}
	}
}
