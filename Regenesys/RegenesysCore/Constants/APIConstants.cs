using System;
using Android.Runtime;

namespace RegenesysCore.Constants
{
    [Preserve(AllMembers = true)]
    public static class APIConstants
    {
        //Pexels API
        public const string PexelsApiKey = "563492ad6f91700001000001b77a0911e4e743c6ab60588032d08131";
        public const string BaseUrl = "https://api.pexels.com/v1/";
        public const string FirstPageEndUrl = "curated?per_page=15";

        //Firebase API
        public const string FirebaseDBApiKey = "https://regenesys-b018f-default-rtdb.firebaseio.com/";
    }
}
