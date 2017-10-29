using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Маме.Domain;

namespace Маме
{
    class Calculator
    {
        public static List<string> CalculateAverage(ObservableCollection<Party> rowData)
        {
            var toSave = new Session();
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

        public static string CalculatePertene (ObservableCollection<PerteneData> rowData)
        {
            var weightSum = rowData.Sum(row => row.Weight);
            foreach (var row in rowData)
            {
                row.Percentage = CalculatePercentage(row.Weight, weightSum);
                row.cpX = 6000 / (row.cP - 50);
            }
            var sum = rowData.Sum(row => row.cpX * row.Percentage / 100);
            var result = (6000 + sum * 50) / sum;
            return result.ToString(CultureInfo.InvariantCulture);
        }

        public static (string resultA, string resultB) CalculateCP (ObservableCollection<CP> cpData, string requiredCP)
        {
            if (cpData.Count < 2) return ("", "");
            var requiredCp = double.Parse(requiredCP);
            var cp = 6000 / (requiredCp - 50);
            var percentageA = (cp * 100 - 100 * cpData[1].cpX) / (cpData[0].cpX - cpData[1].cpX);
            return (percentageA.ToString(CultureInfo.InvariantCulture), 
                (100 - percentageA).ToString(CultureInfo.InvariantCulture));
        }
        private static double CalculatePercentage(double numerator, double denumerator) => (numerator / denumerator) * 100;

    }
}
