using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Маме.Domain
{
    internal class DataBase<T>
    {
        private readonly string fileName;

        public DataBase(string fName)
        {
            fileName = fName;
        }

        public List<T> LoadData()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var res = new List<T>();
            try
            {
                using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    var deserilizeSeans = (List<T>) jsonFormatter.ReadObject(fs);
                    res = new List<T>(deserilizeSeans);
                }
            }
            catch (Exception) {}
            return res;
        }

        public void SaveData(T obj)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<T>));
            var list = new List<T>();
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                    list = (List<T>) jsonFormatter.ReadObject(fs);
            }
            catch (Exception) {}
            list.Add(obj);
            using (var fs = new FileStream(fileName, FileMode.Create))
                jsonFormatter.WriteObject(fs, list);
        }
    }
}