using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using RegenesysCore.Utils;
using SQLite;

namespace RegenesysCore.Services
{
    [Android.Runtime.Preserve(AllMembers = true)]
    public class PhotoDatabase : IPhotoDatabase<PhotoResult>
    {
        #region Fields

        SQLiteAsyncConnection _fdatabase;

        #endregion

        #region Constructor

        public PhotoDatabase()
        {
            _fdatabase = new SQLiteAsyncConnection(DatabaseUtils.DatabasePath, DatabaseUtils.Flags);
        }

        #endregion

        #region Interface Methods

        public async Task CreateTableAsync()
        {
            _ = await _fdatabase.CreateTableAsync<PhotoResult>();
        }

        public Task<PhotoResult> GetPhotoAsync(int id)
        {
            return _fdatabase.Table<PhotoResult>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PhotoResult>> GetPhotosAsync()
        {
            return await _fdatabase.Table<PhotoResult>().ToListAsync();
        }

        public async Task<int> StorePhotoAsync(PhotoResult item)
        {
            return await _fdatabase.InsertAsync(item);
        }

        public async Task<int> DeletePhotoAsync(PhotoResult item)
        {
            return await _fdatabase.DeleteAsync(item);
        }

        #endregion
    }
}
