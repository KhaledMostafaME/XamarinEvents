using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinEvents.Models;

namespace XamarinEvents.Service
{
    interface IEventsApi
    {
        [Post("/api/EventCalendar/SearchEvents")]
        Task<EventsApiResponse> GetEvents([Body] Search search);
    }
}
