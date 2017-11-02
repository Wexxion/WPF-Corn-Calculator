﻿using System;
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
    public partial class Task1History
    {
        private DataBase<PerteneSession> db = new DataBase<PerteneSession>("PerteneData.json");
        public Task1History(Window main)
        {
            InitializeComponent();
            var items = db.LoadData();
            Sessions.ItemsSource = items;
            Closing += (sender, args) => main.Show();
        }
    }
}
