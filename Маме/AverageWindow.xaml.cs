using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Controls;

namespace Маме
{
    /// <summary>
    /// Логика взаимодействия для AverageWindow.xaml
    /// </summary>
    /// 
    [Serializable]
    public class Seans
    {
        public List<Party> Parties { get; set; }
        public double Sum { get; set; }
        public List<double> Results { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }


        public void Save()
        {
            Date = DateTime.Now;
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Seans>));
            var list = new List<Seans>();

            try
            {
                using (FileStream fs = new FileStream("Average.json", FileMode.Open))
                    list = (List<Seans>) jsonFormatter.ReadObject(fs);
            } catch (SerializationException) {}

            list.Add(this);
            using (FileStream fs = new FileStream("Average.json", FileMode.Create))
                jsonFormatter.WriteObject(fs, list);
        }
    }
    [Serializable]
    public class Party
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
    }
    public partial class AverageWindow : Window
    {
        public ObservableCollection<Party> RowData { get; set; }
        public Dictionary<int, TextBox> Conformity = new Dictionary<int, TextBox>(); 

        public AverageWindow(Window main)
        {
            
           // main.Hide();
            InitializeComponent();
            Conformity.Add(0, Zero);
            Conformity.Add(1, One);
            Conformity.Add(2, Two);
            Conformity.Add(3, Three);
            Conformity.Add(4, Four);
            Conformity.Add(5, Five);
            Conformity.Add(6, Six);
            Row.ItemsSource = RowData = new ObservableCollection<Party>();
            Closing += (sender, args) => main.Show();
        }

        private void OnDeleteData(object sender, RoutedEventArgs e)
        {
            RowData.Remove(((FrameworkElement) sender).DataContext as Party);
        }

        private void OnAddData(object sender, RoutedEventArgs e)
        {
            RowData.Add(new Party());
        }

        private void CountUp(object sender, RoutedEventArgs e)
        {
            var toSave = new Seans();
            var sum = GetSum();
            toSave.Sum = sum;
            toSave.Parties = RowData.ToList();
            toSave.Results = new List<double>();
            Conformity[0].Text =sum.ToString(CultureInfo.InvariantCulture);
            var allValues = RowData.Select(row => row.GetAll()).ToList();
            toSave.Results.Add(sum);
            for (var i = 1; i < 7; i++)
            {
                var res = allValues.Sum(row => row[0]*row[i])/sum;
                Conformity[i].Text = res.ToString(CultureInfo.InvariantCulture);
                toSave.Results.Add(res);
            }
            toSave.Save();
        }
        private double GetSum() => RowData.Sum(row => row.Weight);
    }
}
