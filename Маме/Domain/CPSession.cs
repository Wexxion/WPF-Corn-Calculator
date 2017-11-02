using System;
using System.Collections.Generic;

namespace Маме.Domain
{
    [Serializable]
    class CPSession :ISession
    {

        public List<CPData> Parties { get; set; }
        public double RequiredCp { get; set; }
        public List<double> Results { get; set; }
        public DateTime Date { get; set; }
        public void Save()
        {
            var db = new DataBase<CPSession>("CPData.json");
            Date = DateTime.Now;
            db.SaveData(this);
        }
    }
}
