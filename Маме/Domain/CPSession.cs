using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Маме.Domain
{
    class CPSession :ISession
    {

        public List<CP> Parties { get; set; }
        public double RequiredCp { get; set; }
        public List<double> Results { get; set; } = new List<double>();
        public DateTime Date { get; set; }
        public void Save()
        {
            var db = new DataBase<CPSession>("CPData.json");
            Date = DateTime.Now;
            db.SaveData(this);
        }
    }
}
