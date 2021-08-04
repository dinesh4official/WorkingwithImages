using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Runtime;

namespace RegenesysCore.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface IPhotoDatabase<T>
    {
        #region Methods

        Task CreateTableAsync();

        Task<List<T>> GetPhotosAsyncFromDB();

        Task<T> GetPhotoAsyncFromDB(int id);

        Task StorePhotoAsyncInDB(T item);

        Task<int> DeletePhotoAsyncFromDB(T item);

        #endregion
    }
}
