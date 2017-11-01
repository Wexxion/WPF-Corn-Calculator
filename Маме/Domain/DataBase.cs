using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Маме.Domain;

namespace Маме
{
    class DataBase<T>
    {
        private string fileName;
        public DataBase(string fName) => fileName = fName;
        public List<T> LoadData()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                var deserilizeSeans = (List<T>)jsonFormatter.ReadObject(fs);
                return new List<T>(deserilizeSeans);
            }
        }
        public void SaveData(T obj)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var list = new List<T>();
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    list = (List<T>)jsonFormatter.ReadObject(fs);
                }
            }
            catch (FileNotFoundException)
            {
            }
            list.Add(obj);
            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, list);
            }
        }
    }
}
