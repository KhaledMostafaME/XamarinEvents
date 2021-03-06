﻿using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinEvents.Service;

namespace XamarinEvents.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
		}

        private async void EventsButton_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EventsPage());
        }

        private async void MediaButton_ClickedAsync(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new MediaPage());
        }
    }
}