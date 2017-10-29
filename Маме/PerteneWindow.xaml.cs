using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;


namespace Маме
{
    /// <summary>
    /// Логика взаимодействия для PerteneWindow.xaml
    /// </summary>
    /// 
    public class Data
    {
        public double Weight { get; set; }
        public double cP { get; set; }
        public double Percentage;
        public double cpX;
        public List<double> GetAll()
        {
            return new List<double> {Weight, cP};
        }
    }

    public class CP
    {
        public double cP { get; set; }
        public double Result { get; set; }
        public double cpX { get {
                return 6000 / (cP - 50);
            } }
    }

    public partial class PerteneWindow : Window
    {
        public ObservableCollection<Data> RowData { get; set; }
        public ObservableCollection<CP> CPData { get; set; }
        
        public PerteneWindow(Window main)
        {
            main.Hide();
            InitializeComponent();
            Row.ItemsSource = RowData = new ObservableCollection<Data>();
            CP.ItemsSource = CPData = new ObservableCollection<CP>();
            Closing += (sender, args) => main.Show();
        }

        private void OnDeleteData(object sender, RoutedEventArgs e)=>
            RowData.Remove(((FrameworkElement) sender).DataContext as Data);

        private void OnAddData(object sender, RoutedEventArgs e) =>
            RowData.Add(new Data());

        private void CountUp(object sender, RoutedEventArgs e)
        {
            var weightSum = RowData.Sum(row => row.Weight);
            foreach (var row in RowData)
            {
                row.Percentage = CalculatePercentage(row.Weight, weightSum);
                row.cpX = CalculateCP(row.cP);
            }
            var sum = RowData.Sum(row => row.cpX * row.Percentage / 100);
            var result = (6000 + sum * 50) / sum;
            Zero.Text = result.ToString(CultureInfo.InvariantCulture);
        }
        private void OnAddCp(object sender, RoutedEventArgs e) => CPData.Add(new CP());
        private void OnDeleteCp(object sender, RoutedEventArgs e) =>
            CPData.Remove(((FrameworkElement) sender).DataContext as CP);
        private double CalculateCP(double cp) => 6000 / (cp - 50);
        private double CalculatePercentage(double numerator, double denumerator) => (numerator / denumerator) * 100;

        public void CountUpCP(object sender, RoutedEventArgs e)
        {
            var requiredCp = double.Parse(Required.Text);
            var cp = CalculateCP(requiredCp);
            var percentageA = (cp * 100 - 100 * CPData[1].cpX) / (CPData[0].cpX - CPData[1].cpX);
            resultA.Text = percentageA.ToString();
            resultB.Text = (100 - percentageA).ToString();


        }
    }


}