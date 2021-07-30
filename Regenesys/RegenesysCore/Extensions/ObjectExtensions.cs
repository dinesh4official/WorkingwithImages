using System;
using Android.Runtime;

namespace RegenesysCore.Extensions
{
    [Preserve(AllMembers = true)]
    public static class ObjectExtensions
    {
        #region Methods

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        #endregion
    }
}
