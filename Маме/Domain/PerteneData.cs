using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;

namespace Маме.Domain
{
    [Serializable]
    public class PerteneData
    {
        public double Weight { get; set; }
        public double cP { get; set; }
        public double Percentage;
        public double cpX;
        public List<double> GetAll() => new List<double> { Weight, cP };
        
        public static (string res, double sum) CalculatePertene(ObservableCollection<PerteneData> rowData)
        {
            var toSave = new PerteneSession {Data = rowData.ToList()};
            var weightSum = rowData.Sum(row => row.Weight);
            foreach (var row in rowData)
            {
                row.Percentage = CalculatePercentage(row.Weight, weightSum);
                row.cpX = 6000 / (row.cP - 50);
            }
            var sum = rowData.Sum(row => row.cpX * row.Percentage / 100);
            
            var result = (6000 + sum * 50) / sum;
            toSave.Result = result;
            toSave.Sum = sum;
            toSave.Save();
            return (result.ToString(CultureInfo.InvariantCulture), sum);
        }

        private static double CalculatePercentage(double numerator, double denumerator) => (numerator / denumerator) * 100;
    }
}
