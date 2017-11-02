using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Маме.Domain
{
    [Serializable]
    public class CPData
    {
        public double cP { get; set; }
        public string Result { get; set; }
        public double cpX => 6000 / (cP - 50);

        public static void CalculateCP(ObservableCollection<CPData> cpData, string requiredCP, List<TextBlock> results)
        {
            var toSave = new CPSession { Parties = cpData.ToList() };
            if (cpData.Count < 2 || string.IsNullOrEmpty(requiredCP)) return;
            var requiredCp = Double.Parse(requiredCP);
            toSave.RequiredCp = requiredCp;
            var cp = 6000 / (requiredCp - 50);
            var percentageA = (cp * 100 - 100 * cpData[1].cpX) / (cpData[0].cpX - cpData[1].cpX);
            toSave.Results.Add(percentageA);
            toSave.Results.Add(100 - percentageA);
            toSave.Save();

            results[0].Text = cpData[0].Result = percentageA.ToString("0.0000");
            results[1].Text = cpData[1].Result = (100 - percentageA).ToString("0.0000");
        }
    }
}
