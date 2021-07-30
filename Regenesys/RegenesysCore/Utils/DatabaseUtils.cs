using System;
using System.IO;
using RegenesysCore.Constants;

namespace RegenesysCore.Utils
{
    [Android.Runtime.Preserve(AllMembers = true)]
    public static class DatabaseUtils
    {
        #region Fields

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create |
                                                    SQLite.SQLiteOpenFlags.SharedCache;

        #endregion

        #region Properties

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, AppConstants.DatabaseFilename);
            }
        }

        #endregion
    }
}
