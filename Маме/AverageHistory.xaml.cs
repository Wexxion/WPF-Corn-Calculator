using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace Маме
{
    public partial class AverageHistory : Window
    {
        public AverageHistory(Window main)
        {
            InitializeComponent();

            LoadData();
            Closing += (sender, args) => main.Show();
        }

        public void LoadData()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Seans>));
            using (var fs = new FileStream("Average.json", FileMode.Open))
            {
                var deserilizeSeans = (List<Seans>) jsonFormatter.ReadObject(fs);
                Seanses.ItemsSource = new List<Seans>(deserilizeSeans);
                for (var i = 1; i <= deserilizeSeans.Count; i++)
                    deserilizeSeans[i - 1].Number = i;
            }
        }
    }
}