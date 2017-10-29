using System.Collections.Generic;

namespace Маме.Domain
{
    public class PerteneData
    {
        public double Weight { get; set; }
        public double cP { get; set; }
        public double Percentage;
        public double cpX;
        public List<double> GetAll()
        {
            return new List<double> { Weight, cP };
        }
    }

    public class CP
    {
        public double cP { get; set; }
        public double Result { get; set; }
        public double cpX => 6000 / (cP - 50);
    }
}
