using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Маме.Domain
{
    [Serializable]
    class PerteneSession: ISession
    {
        public List<PerteneData> Data { get; set; }
        public double Result { get; set; }
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
