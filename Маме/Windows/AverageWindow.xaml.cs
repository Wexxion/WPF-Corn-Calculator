using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Маме.Domain;

namespace Маме
{
    public partial class AverageWindow
    {
        public Dictionary<int, TextBox> Conformity;

        public AverageWindow(Window main)
        {
            main.Hide();
            InitializeComponent();
            Conformity = new Dictionary<int, TextBox>
            {
                {0, Zero},
                {1, One},
                {2, Two},
                {3, Three},
                {4, Four},
                {5, Five},
                {6, Six}
            };
            Row.ItemsSource = RowData = new ObservableCollection<AverageParty>();
            Closing += (sender, args) => main.Show();
        }

        public ObservableCollection<AverageParty> RowData { get; set; }

        private void OnDeleteData(object sender, RoutedEventArgs e)
            => RowData.Remove(((FrameworkElement)sender).DataContext as AverageParty);

        private void OnAddData(object sender, RoutedEventArgs e) => RowData.Add(new AverageParty());

        private void CountUp(object sender, RoutedEventArgs e)
        {
            var result = AverageParty.CalculateAverage(RowData);
            for (var i = 0; i < result.Count; i++)
                Conformity[i].Text = result[i];
        }
    }
}