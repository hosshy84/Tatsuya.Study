using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using DevDaysSpeakers.Model;
using Plugin.TextToSpeech;

using DevDaysSpeakers.ViewModel;

namespace DevDaysSpeakers.View
{
    public partial class DetailsPage : ContentPage
    {
        Speaker speaker;
		SpeakersViewModel viewModel;
		public DetailsPage()
		{
			InitializeComponent();
		}
		public DetailsPage(Speaker speaker, SpeakersViewModel viewModel) : this()
        {
            //Set local instance of speaker and set BindingContext
            this.speaker = speaker;
			this.viewModel = viewModel;
            BindingContext = this.speaker;

			ButtonSpeak.Clicked += ButtonSpeak_Clicked;
			ButtonWebsite.Clicked += ButtonWebsite_Clicked;
			ButtonSave.Clicked += ButtonSave_Clicked;
        }

		void ButtonSpeak_Clicked(object sender, EventArgs e)
		{
			CrossTextToSpeech.Current.Speak(this.speaker.Description);
		}

		void ButtonWebsite_Clicked(object sender, EventArgs e)
		{
			if (speaker.Website.StartsWith("http"))
				Device.OpenUri(new Uri(speaker.Website));
		}

		async void ButtonSave_Clicked(object sender, EventArgs e)
		{
			speaker.Title = EntryTitle.Text;
			await viewModel.UpdateSpeaker(speaker);
			await Navigation.PopAsync();
		}
    }
}
