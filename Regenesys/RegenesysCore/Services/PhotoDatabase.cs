using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using RegenesysCore.Utils;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace RegenesysCore.Services
{
    [Android.Runtime.Preserve(AllMembers = true)]
    public class PhotoDatabase : IPhotoDatabase<PhotoResult>
    {
        #region Fields

        SQLiteConnection _fdatabase;

        #endregion

        #region Constructor

        public PhotoDatabase()
        {
            _fdatabase = new SQLiteConnection(DatabaseUtils.DatabasePath, DatabaseUtils.Flags);
        }

        #endregion

        #region Interface Methods

        public async Task CreateTableAsync()
        {
            _ = _fdatabase.CreateTable<PhotoSource>();
            _ = _fdatabase.CreateTable<PhotoResult>();
            await Task.CompletedTask;
        }

        public async Task<PhotoResult> GetPhotoAsyncFromDB(int id)
        {
            var item = _fdatabase.Table<PhotoResult>().Where(i => i.Id == id).FirstOrDefault();
            var photoResult = _fdatabase.GetWithChildren<PhotoResult>(item.PhotoId);
            await Task.CompletedTask;
            return photoResult;
        }

        public async Task<List<PhotoResult>> GetPhotosAsyncFromDB()
        {
            var items = _fdatabase.GetAllWithChildren<PhotoResult>();
            await Task.CompletedTask;
            return items;
        }

        public async Task StorePhotoAsyncInDB(PhotoResult item)
        {
            _ = _fdatabase.Insert(item);
            _ = _fdatabase.Insert(item.Source);
            _fdatabase.UpdateWithChildren(item);
            await Task.CompletedTask;
        }

        public async Task<int> DeletePhotoAsyncFromDB(PhotoResult item)
        {
            var result = _fdatabase.Delete(item);
            await Task.CompletedTask;
            return result;
        }

        #endregion
    }
}
