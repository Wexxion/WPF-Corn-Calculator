using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;
using Маме.Domain;

namespace Маме
{
    public partial class AverageHistory
    {
        private DataBase<AverageSession> db = new DataBase<AverageSession>("Average.json");
        public AverageHistory(Window main)
        {
            InitializeComponent();
            var items = db.LoadData();
            Seanses.ItemsSource = items;
            Closing += (sender, args) => main.Show();
        }

    }
}