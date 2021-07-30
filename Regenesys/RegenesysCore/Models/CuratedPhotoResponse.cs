using System;
using System.Collections.Generic;
using Android.Runtime;
using Newtonsoft.Json;

namespace RegenesysCore.Models
{
    [Preserve(AllMembers = true)]
    public class CuratedPhotoResponse
    {
        #region Properties

        /// <summary>
        /// The current page number.
        /// </summary>
        [JsonProperty("page")]
        public int CurrentPageNumber { get; set; }

        /// <summary>
        /// The number of results returned with each page.
        /// </summary>
        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        /// <summary>
        /// An array of Photo objects.
        /// </summary>
        [JsonProperty("photos")]
        public List<PhotoResult> Photos { get; set; }

        /// <summary>
        /// The total number of results for the request.
        /// </summary>
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        /// <summary>
        /// URL for the previous page of results, if applicable.
        /// </summary>
        [JsonProperty("prev_page")]
        public string PrevPageURL { get; set; }

        /// <summary>
        /// URL for the next page of results, if applicable.
        /// </summary>
        [JsonProperty("next_page")]
        public string NextPageURL { get; set; }

        #endregion
    }
}
