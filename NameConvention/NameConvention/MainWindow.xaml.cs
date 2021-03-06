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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NameConvention.db_features;

namespace NameConvention
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Convention CurrentConvention;
        public DbStructure Structure;
        public TableUserControl tableUserControl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            generalFrame.Navigate(new CreateConnectionUserControl());
        }
        
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            generalFrame.Navigate(new ReferenceUserControl());
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            generalFrame.Navigate(new AboutCreatorsUserControl());
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Structure.FillStructure(Connector.GetConnection(Connector.Name, Connector.Password, Connector.Db_name));
            generalFrame.Navigate(tableUserControl);
            tableUserControl.Update(Structure);
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            generalFrame.Navigate(new PatternsUserControl(this));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
