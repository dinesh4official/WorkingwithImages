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

        Task<List<T>> GetPhotosAsync();

        Task<T> GetPhotoAsync(int id);

        Task<int> StorePhotoAsync(T item);

        Task<int> DeletePhotoAsync(T item);

        #endregion
    }
}
