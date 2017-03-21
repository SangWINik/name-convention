using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for CreateConnectionUserControl.xaml
    /// </summary>
    public partial class CreateConnectionUserControl : UserControl
    {
        public CreateConnectionUserControl()
        {
            InitializeComponent();
        }

        private MainWindow _mainWindow;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow = (MainWindow)Window.GetWindow(this);
            _mainWindow.Structure = new DbStructure();
            _mainWindow.Structure.FillStructure(Connector.GetConnection(NameTextBox.Text, PasswordTextBox.Text, DBTextBox.Text));
            _mainWindow.tableUserControl = new TableUserControl(_mainWindow.Structure);
            _mainWindow.generalFrame.Navigate(_mainWindow.tableUserControl);
        }
    }
}
