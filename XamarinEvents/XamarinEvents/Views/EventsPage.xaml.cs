using Acr.UserDialogs;
using FFImageLoading.Forms;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinEvents.Models;
using XamarinEvents.Service;

namespace XamarinEvents.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventsPage : ContentPage
	{
        EventsApiResponse res = new EventsApiResponse();
        PushMsg pushMsg = new PushMsg();

        public EventsPage ()
		{
			InitializeComponent ();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

        }

        async void GetEvents_ClickedAsync(object sender, System.EventArgs e)
        {


            pushMsg.sendToast("Loading Events...",3000, Color.Red);

            var payload = new Search
            {

                categoryID = "0",
                cityID = 0,
                eventId = "",
                eventTitle = null,
                fromDate = "Thu Jul 27 2017",
                lang = "en",
                pageSize = 200,
                regionID = 0,
                startIndex = 0,
                toDate = "Sun Dec 31 2017"
            };

            var apiResponse = RestService.For<IEventsApi>("http://www.saudievents.sa");
            res = await apiResponse.GetEvents(payload);
            EventsList.ItemsSource = res.Records;
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBar.Text))
                EventsList.ItemsSource = res.Records;
            else
                return;

        }

        private void searchBar_SearchButtonPressed(object sender, System.EventArgs e)
        {

            if (res.Records != null)
            {
                if (searchPicker.SelectedIndex == -1)
                    pushMsg.sendToast("Select item to search by", 3000, Color.Red);
                else
                {

                
                EventsList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(searchBar.Text))
                {
                    EventsList.ItemsSource = res.Records;
                }
                else{
         
                    if (searchPicker.SelectedIndex == 0)
                        EventsList.ItemsSource = res.Records.Where(i => i.EventTitle.IndexOf(searchBar.Text, System.StringComparison.OrdinalIgnoreCase) != -1);
                    else if (searchPicker.SelectedIndex == 1)
                        EventsList.ItemsSource = res.Records.Where(i => i.EventStartDate.Contains(searchBar.Text));
                    else if (searchPicker.SelectedIndex == 2)
                        EventsList.ItemsSource = res.Records.Where(i => i.EventEndDate.Contains(searchBar.Text));
                    else if (searchPicker.SelectedIndex == 3)
                        EventsList.ItemsSource = res.Records.Where(i => i.CityEnName.IndexOf(searchBar.Text, System.StringComparison.OrdinalIgnoreCase) != -1);

                }
                EventsList.EndRefresh();
                }
            }
            else
                pushMsg.sendToast("Get Events first", 3000, Color.Red);


            Debug.WriteLine("Test null");
        }



    }
}