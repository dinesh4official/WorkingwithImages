using System;
using Newtonsoft.Json;

namespace RegenesysCore.Utils
{
    [Android.Runtime.Preserve(AllMembers = true)]
    public static class JSONUtils
    {
        public static string SerializeObject<T>(T item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented);
        }

        public static T DeserializeObject<T>(string item)
        {
            return JsonConvert.DeserializeObject<T>(item);
        }
    }
}
