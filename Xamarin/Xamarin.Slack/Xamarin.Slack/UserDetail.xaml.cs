using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Slack.Model;
using Xamarin.Slack.ViewModel;
using Plugin.TextToSpeech;

namespace Xamarin.Slack
{
	public partial class UserDetail : ContentPage
	{
		User user;
		UsersViewModel viewModel;

		public UserDetail(User user, UsersViewModel viewModel)
		{
			InitializeComponent();

			this.user = user;
			this.viewModel = viewModel;

			BindingContext = this.user;

			ButtonSpeak.Clicked += ButtonSpeak_Clicked;
		}

		void ButtonSpeak_Clicked(object sender, EventArgs e)
		{
			CrossTextToSpeech.Current.Speak(user.RealName);
		}
	}
}
