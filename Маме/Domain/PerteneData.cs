using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Маме.Domain
{
    [Serializable]
    public class PerteneData
    {
        public double Weight { get; set; }
        public double cP { get; set; }
        public double Percentage;
        public double cpX;
        public List<double> GetAll() =>
            new List<double> { Weight, cP };
        
        public static (string res, double sum) CalculatePertene(ObservableCollection<PerteneData> rowData)
        {
            var toSave = new PerteneSession {data = rowData.ToList()};
            var weightSum = rowData.Sum(row => row.Weight);
            foreach (var row in rowData)
            {
                row.Percentage = CalculatePercentage(row.Weight, weightSum);
                row.cpX = 6000 / (row.cP - 50);
            }
            var sum = rowData.Sum(row => row.cpX * row.Percentage / 100);
            
            var result = (6000 + sum * 50) / sum;
            toSave.result = result;
            toSave.Sum = sum;
            toSave.Save();
            return (result.ToString(CultureInfo.InvariantCulture), sum);
        }

        private static double CalculatePercentage(double numerator, double denumerator) => (numerator / denumerator) * 100;
    }
    [Serializable]
    public class CP
    {
        public double cP { get; set; }
        public double Result { get; set; }
        public double cpX => 6000 / (cP - 50);

        public static (string resultA, string resultB) CalculateCP(ObservableCollection<CP> cpData, string requiredCP)
        {
            var toSave = new CPSession {Parties = cpData.ToList()};
            if (cpData.Count < 2) return ("", "");
            var requiredCp = Double.Parse(requiredCP);
            toSave.RequiredCp = requiredCp;
            var cp = 6000 / (requiredCp - 50);
            var percentageA = (cp * 100 - 100 * cpData[1].cpX) / (cpData[0].cpX - cpData[1].cpX);
            toSave.Results.Add(percentageA);
            toSave.Results.Add(100 - percentageA);
            toSave.Save();
            return (percentageA.ToString(CultureInfo.InvariantCulture),
                (100 - percentageA).ToString(CultureInfo.InvariantCulture));
        }
    }
}
