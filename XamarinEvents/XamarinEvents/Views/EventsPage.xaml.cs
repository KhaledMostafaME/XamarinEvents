using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public EventsPage ()
		{
			InitializeComponent ();
		}


        async void GetEvents_ClickedAsync(object sender, System.EventArgs e)
        {

            var payload = new Search
            {

                categoryID = "0",
                cityID = 0,
                eventId = "",
                eventTitle = null,
                fromDate = "Thu Jul 27 2017",
                lang = "en",
                pageSize = 50,
                regionID = 0,
                startIndex = 0,
                toDate = "Sun Dec 31 2017"
            };

            var apiResponse = RestService.For<IEventsApi>("http://www.saudievents.sa");
            EventsApiResponse res = await apiResponse.GetEvents(payload);
            EventsList.ItemsSource = res.Records;
        }

        public async Task<IList<Record>> GetEventsAsync()
        {

            var payload = new Search
            {

                categoryID = "0",
                cityID = 0,
                eventId = "",
                eventTitle = null,
                fromDate = "Thu Jul 27 2017",
                lang = "en",
                pageSize = 50,
                regionID = 0,
                startIndex = 0,
                toDate = "Sun Dec 31 2017"
            };

            var apiResponse = RestService.For<IEventsApi>("http://www.saudievents.sa");
            EventsApiResponse res = await apiResponse.GetEvents(payload);
            return res.Records;
        }
    }
}