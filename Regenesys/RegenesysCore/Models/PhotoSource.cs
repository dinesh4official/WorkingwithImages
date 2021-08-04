using System;
using Newtonsoft.Json;
using RegenesysCore.Constants;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RegenesysCore.Models
{
    [Android.Runtime.Preserve(AllMembers = true)]
    [Table(AppConstants.PhotoSource)]
    public class PhotoSource
    {
        #region Properties

        /// <summary>
        /// Used to add the <see cref="PhotoSource"/> in SQLite.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// ForeignKey for <see cref="PhotoResult"/>.
        /// </summary>
        [ForeignKey(typeof(PhotoResult))]
        public int PhotoResultId { get; set; }

        /// <summary>
        /// The image without any size changes.
        /// It will be the same as the width and height attributes.
        /// </summary>
        [JsonProperty("original")]
        public string Original { get; set; }

        /// <summary>
        /// The image resized to W 940px X H 650px DPR 1.
        /// </summary>
        [JsonProperty("large")]
        public string Large { get; set; }

        /// <summary>
        /// The image resized W 940px X H 650px DPR 2.
        /// </summary>
        [JsonProperty("large2x")]
        public string ExtraLarge { get; set; }

        /// <summary>
        /// The image scaled proportionally so that it's new height is 350px.
        /// </summary>
        [JsonProperty("medium")]
        public string Medium { get; set; }

        /// <summary>
        /// The image scaled proportionally so that it's new height is 130px.
        /// </summary>
        [JsonProperty("small")]
        public string Small { get; set; }

        /// <summary>
        /// The image cropped to W 800px X H 1200px.
        /// </summary>
        [JsonProperty("portrait")]
        public string Portrait { get; set; }

        /// <summary>
        /// The image cropped to W 1200px X H 627px.
        /// </summary>
        [JsonProperty("landscape")]
        public string Landscape { get; set; }

        /// <summary>
        /// The image cropped to W 280px X H 200px.
        /// </summary>
        [JsonProperty("tiny")]
        public string Tiny { get; set; }

        #endregion
    }
}
