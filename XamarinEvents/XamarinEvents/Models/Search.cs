using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinEvents.Models
{
    class Search
    {
        [JsonProperty("categoryID")]
        public string categoryID { get; set; }

        [JsonProperty("cityID")]
        public int cityID { get; set; }

        [JsonProperty("eventId")]
        public string eventId { get; set; }

        [JsonProperty("eventTitle")]
        public string eventTitle { get; set; }

        [JsonProperty("fromDate")]
        public string fromDate { get; set; }

        [JsonProperty("lang")]
        public string lang { get; set; }

        [JsonProperty("pageSize")]
        public int pageSize { get; set; }

        [JsonProperty("regionID")]
        public int regionID { get; set; }

        [JsonProperty("startIndex")]
        public int startIndex { get; set; }

        [JsonProperty("toDate")]
        public string toDate { get; set; }
    }
}
