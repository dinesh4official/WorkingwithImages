using System;
using Android.Runtime;

namespace RegenesysCore.Constants
{
    [Preserve(AllMembers = true)]
    public static class AppConstants
    {
        public const string Error = "ERROR";
        public const string Authorization = "Authorization";
        public const string NetworkDetector = "NetworkDetector";
        public const string AvailableConnection = "Network Connected";
        public const string NoConnection = "No Network Connection";
        public const string DatabaseFilename = "RegenesysSQLite.db3";
        public const string BehaviorRegisterError = "CommandBehavior: Can't register the '{0}' event.";
        public const string BehaviorDeRegisterError = "CommandBehavior: Can't de-register the '{0}' event.";
        public const string OnEvent = "OnEvent";
        public const string PhotoResult = "PhotoResult";
        public const string PhotoSource = "PhotoSource";
    }
}
