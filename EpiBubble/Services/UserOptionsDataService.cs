using EpiBubble.Model.DataModel;
using System;
using System.IO;
using Newtonsoft.Json;
using Windows.Storage;
using System.Threading.Tasks;

namespace EpiBubble.Services
{
    public class UserOptionsDataService : IDataService<UserOptions>
    {
        const string SaveFile = "DataFile.txt";

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<UserOptions> Read()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await storageFolder.GetFileAsync(SaveFile);
            return JsonConvert.DeserializeObject<UserOptions>((await FileIO.ReadTextAsync(file)));
        }

        public async Task<bool> Save(UserOptions item)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            var file = await storageFolder.CreateFileAsync(SaveFile, CreationCollisionOption.FailIfExists);
            await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(item));
            return true;
        }

        public Task<bool> Update(UserOptions item)
        {
            throw new NotImplementedException();
        }
    }
}
