using Android.Gms.Maps.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using XamarinEvents.Models;

namespace XamarinEvents.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent();
            //MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
            //    new Position(37, -122), Distance.FromMiles(1)));
        }

        public MapPage(Record item)
        {
            InitializeComponent();

            var markerOption = new MarkerOptions().SetPosition(new LatLng(item.EventLatitude, item.EventLongitude));
            var eventPin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(item.EventLatitude, item.EventLongitude),
                Label = item.EventTitle,
                Address = item.LocationDesc
            };
            MyMap.Pins.Add(eventPin);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(item.EventLatitude, item.EventLongitude), Distance.FromMiles(5)));

        }

    }
}