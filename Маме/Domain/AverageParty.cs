using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Маме.Domain
{
    [Serializable]
    public class AverageParty
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

        public static List<string> CalculateAverage(ObservableCollection<AverageParty> rowData)
        {
            var toSave = new AverageSession();
            var conformity = new List<string>();
            var sum = rowData.Sum(row => row.Weight);
            toSave.Sum = sum;
            toSave.Parties = rowData.ToList();
            toSave.Results = new List<double>();

            conformity.Add(sum.ToString(CultureInfo.InvariantCulture));
            var allValues = rowData.Select(row => row.GetAll()).ToList();
            toSave.Results.Add(sum);

            for (var i = 1; i < 7; i++)
            {
                var res = allValues.Sum(row => row[0] * row[i]) / sum;
                conformity.Add(res.ToString(CultureInfo.InvariantCulture));
                toSave.Results.Add(res);
            }

            toSave.Save();
            return conformity;
        }
    }
}