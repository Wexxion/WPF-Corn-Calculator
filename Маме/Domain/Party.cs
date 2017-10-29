using System;
using System.Collections.Generic;

namespace Маме.Domain
{
    [Serializable]
    public class Party
    {
        public double Weight { get; set; }
        public double Humidity { get; set; }
        public double Littert { get; set; }
        public double Zern { get; set; }
        public double Natur { get; set; }
        public double Gluten { get; set; }
        public double Vitrescence { get; set; }

        public List<double> GetAll()
        {
            return new List<double> {Weight, Humidity, Littert, Zern, Natur, Gluten, Vitrescence};
        }
    }
}