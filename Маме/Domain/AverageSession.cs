using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Маме.Domain
{
    [Serializable]
    public class AverageSession : ISession
    {
        public List<AverageParty> Parties { get; set; }
        public double Sum { get; set; }
        public List<double> Results { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }


        public void Save()
        {
            var db = new DataBase<AverageSession>("Average.json");
            Date = DateTime.Now;
            db.SaveData(this);
        }
    }
}