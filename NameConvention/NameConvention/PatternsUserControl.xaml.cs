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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NameConvention.db_features;

namespace NameConvention
{
    /// <summary>
    /// Interaction logic for StandardPatternsUserControl.xaml
    /// </summary>
    public partial class PatternsUserControl : UserControl
    {
        public MainWindow mWindow;

        public PatternsUserControl(MainWindow window)
        {
            InitializeComponent();
            mWindow = window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool ch;
                if (patternTablePuraly.IsChecked == true)
                    ch = true;
                else
                    ch = false;
                Convention conv = new Convention(patternName.Text, patternTable.Text, patternColumn.Text,
                    patternPrimaryKey.Text, ch);
                mWindow.CurrentConvention = conv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReloadConventions()
        {
            
        }
    }
}
