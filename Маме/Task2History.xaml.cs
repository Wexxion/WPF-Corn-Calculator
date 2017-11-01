using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Маме.Domain;

namespace Маме
{
    /// <summary>
    /// Логика взаимодействия для Task2History.xaml
    /// </summary>
    public partial class Task2History : Window
    {
        private DataBase<CPSession> db = new DataBase<CPSession>("CPData.json");
        public Task2History(Window main)
        {
            InitializeComponent();
            var items = db.LoadData();
            Seanses.ItemsSource = items;
            Closing += (sender, args) => main.Show();
        }
    }
}
