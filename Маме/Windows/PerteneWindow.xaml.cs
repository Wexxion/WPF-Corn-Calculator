using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Маме.Domain;


namespace Маме
{
    public partial class PerteneWindow 
    {
        public ObservableCollection<PerteneData> RowData { get; set; }
        public ObservableCollection<CPData> CPData { get; set; }
        
        public PerteneWindow(Window main)
        {
            main.Hide();
            InitializeComponent();
            Row.ItemsSource = RowData = new ObservableCollection<PerteneData>();
            CP.ItemsSource = CPData = new ObservableCollection<CPData>();
            Closing += (sender, args) => main.Show();
        }

        private void OnDeleteData(object sender, RoutedEventArgs e)=>
            RowData.Remove(((FrameworkElement) sender).DataContext as PerteneData);

        private void OnAddData(object sender, RoutedEventArgs e) =>
            RowData.Add(new PerteneData());

        private void OnAddCp(object sender, RoutedEventArgs e)
        {
            if (CPData.Count != 2)
                CPData.Add(new CPData());
        }

        private void OnDeleteCp(object sender, RoutedEventArgs e) =>
            CPData.Remove(((FrameworkElement)sender).DataContext as CPData);

        private void CountUp(object sender, RoutedEventArgs e)
        {
            var res = PerteneData.CalculatePertene(RowData);
            Zero.Text = res.res;
            SumWeigth.Text = res.sum.ToString(CultureInfo.InvariantCulture);
        }

        public void CountUpCP(object sender, RoutedEventArgs e)
        {
            var results = new List<TextBlock>();
            foreach (var item in CP.Items)
            {
                var container = CP.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                results.Add(CP.ItemTemplate.FindName("ResultBox", container) as TextBlock);
            }
            Domain.CPData.CalculateCP(CPData, Required.Text, results);
        }
    }


}