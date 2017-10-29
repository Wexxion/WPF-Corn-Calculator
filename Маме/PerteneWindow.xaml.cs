﻿using System.Collections.ObjectModel;
using System.Windows;
using Маме.Domain;


namespace Маме
{
    public partial class PerteneWindow 
    {
        public ObservableCollection<PerteneData> RowData { get; set; }
        public ObservableCollection<CP> CPData { get; set; }
        
        public PerteneWindow(Window main)
        {
            main.Hide();
            InitializeComponent();
            Row.ItemsSource = RowData = new ObservableCollection<PerteneData>();
            CP.ItemsSource = CPData = new ObservableCollection<CP>();
            Closing += (sender, args) => main.Show();
        }

        private void OnDeleteData(object sender, RoutedEventArgs e)=>
            RowData.Remove(((FrameworkElement) sender).DataContext as PerteneData);

        private void OnAddData(object sender, RoutedEventArgs e) =>
            RowData.Add(new PerteneData());

        private void OnAddCp(object sender, RoutedEventArgs e) => CPData.Add(new CP());

        private void OnDeleteCp(object sender, RoutedEventArgs e) =>
            CPData.Remove(((FrameworkElement)sender).DataContext as CP);

        private void CountUp(object sender, RoutedEventArgs e) 
            => Zero.Text = Calculator.CalculatePertene(RowData);

        public void CountUpCP(object sender, RoutedEventArgs e) 
            => (resultA.Text, resultB.Text) = Calculator.CalculateCP(CPData, Required.Text);
    }


}