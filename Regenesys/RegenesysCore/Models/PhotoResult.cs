using System;
using Newtonsoft.Json;
using RegenesysCore.Constants;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RegenesysCore.Models
{
    [Android.Runtime.Preserve(AllMembers = true)]
    [Table(AppConstants.PhotoResult)]
    public class PhotoResult : NotifyListener
    {
        #region Fields

        byte[] _fImageBytes;

        #endregion

        #region Properties

        /// <summary>
        /// Used to add the <see cref="PhotoResult"/> in SQLite.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int PhotoId { get; set; }

        /// <summary>
        /// The id of the photo.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The real width of the photo in pixels.
        /// </summary>
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// The real height of the photo in pixels.
        /// </summary>
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// The Pexels URL where the photo is located.
        /// </summary>
        [JsonProperty("url")]
        public string ImageURL { get; set; }

        /// <summary>
        /// The name of the photographer who took the photo.
        /// </summary>
        [JsonProperty("photographer")]
        public string Photographer { get; set; }

        /// <summary>
        /// The URL of the photographer's Pexels profile.
        /// </summary>
        [JsonProperty("photographer_url")]
        public string PhotographerURL { get; set; }

        /// <summary>
        /// The id of the photographer.
        /// </summary>
        [JsonProperty("photographer_id")]
        public string PhotographerId { get; set; }

        /// <summary>
        /// The average color of the photo.
        /// Useful for a placeholder while the image loads.
        /// </summary>
        [JsonProperty("avg_color")]
        public string AverageColor { get; set; }

        /// <summary>
        /// An assortment of different image sizes that can be used to display this Photo.
        /// </summary>
        [JsonProperty("src")]
        [OneToOne]
        public PhotoSource Source { get; set; }

        /// <summary>
        /// Indicates whether the photo is liked by any user.
        /// </summary>
        [JsonProperty("liked")]
        public bool IsLiked { get; set; }

        /// <summary>
        /// ForeignKey for <see cref="PhotoSource"/>.
        /// </summary>
        [ForeignKey(typeof(PhotoSource))]
        public int PhotoSourceId { get; set; }

        /// <summary>
        /// Stores the <see cref="ImageURL"/> as bytes.
        /// </summary>
        public byte[] ImageBytes
        {
            get => _fImageBytes;
            set
            {
                _fImageBytes = value;
                OnPropertyChanged(nameof(ImageBytes));
            }
        }

        #endregion
    }
}
