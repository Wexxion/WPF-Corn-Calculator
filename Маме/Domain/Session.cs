using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Маме.Domain
{
    [Serializable]
    public class Session
    {
        public List<Party> Parties { get; set; }
        public double Sum { get; set; }
        public List<double> Results { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }


        public void Save()
        {
            Date = DateTime.Now;
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Session>));
            var list = new List<Session>();

            try
            {
                using (var fs = new FileStream("Average.json", FileMode.Open))
                {
                    list = (List<Session>) jsonFormatter.ReadObject(fs);
                }
            }
            catch (SerializationException)
            {
            }

            list.Add(this);
            using (var fs = new FileStream("Average.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, list);
            }
        }
    }
}