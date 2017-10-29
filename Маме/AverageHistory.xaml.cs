using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;
using Маме.Domain;

namespace Маме
{
    public partial class AverageHistory
    {
        public AverageHistory(Window main)
        {
            InitializeComponent();

            LoadData();
            Closing += (sender, args) => main.Show();
        }

        public void LoadData()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Session>));
            using (var fs = new FileStream("Average.json", FileMode.Open))
            {
                var deserilizeSeans = (List<Session>) jsonFormatter.ReadObject(fs);
                Seanses.ItemsSource = new List<Session>(deserilizeSeans);
                for (var i = 1; i <= deserilizeSeans.Count; i++)
                    deserilizeSeans[i - 1].Number = i;
            }
        }
    }
}