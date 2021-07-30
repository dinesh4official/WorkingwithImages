using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Runtime;

namespace RegenesysCore.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface IFirebaseClient<T>
    {
        #region Methods

        void CreateFirebaseClient(string url);

        Task StoreDatainFirebaseClient(T item, string resourceName);

        Task<List<T>> GetItemsFromFirebaseClient(string resourceName);

        Task<bool> HasItemInDB(T item, string resourceName);

        #endregion
    }
}
