using EpiBubble.Model.DataModel;
using System;
using System.IO;
using Newtonsoft.Json;

namespace EpiBubble.Services
{
    public class UserOptionsDataService : IDataService<UserOptions>
    {
        const string SaveDir = "DataDir";
        const string SaveFile = "DataFile.txt";

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public UserOptions Read()
        {
            if (Directory.Exists(SaveDir))
            {
                return ReadFromFile();
            }
            else
            {
                Directory.CreateDirectory(SaveDir);
                return ReadFromFile();
            }
        }

        public bool Save(UserOptions item)
        {
            if(Directory.Exists(SaveDir))
            {
                return WriteToFile(item);
            }
            else
            {
                Directory.CreateDirectory(SaveDir);
                return WriteToFile(item);
            }
        }

        UserOptions ReadFromFile()
        {
            try
            {
                using (var reader = new StreamReader($"{SaveDir}\\{SaveFile}"))
                {
                    return JsonConvert.DeserializeObject<UserOptions>(reader.ReadLine());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        bool WriteToFile(UserOptions item)
        {
            try
            {
                using (var writer = new StreamWriter($"{SaveDir}\\{SaveFile}"))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(item));
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(UserOptions item)
        {
            throw new NotImplementedException();
        }
    }
}
