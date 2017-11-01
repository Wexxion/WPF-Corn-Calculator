using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Маме.Domain
{
    class PerteneSession: ISession
    {
        public List<PerteneData> data { get; set; }
        public double result { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public void Save()
        {
            var db = new DataBase<PerteneSession>("PerteneData.json");
            Date = DateTime.Now;
            db.SaveData(this);
            
        }
    }
}
