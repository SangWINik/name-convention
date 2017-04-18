using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Data.SqlClient;

namespace NameConvention
{
    /// <summary>
    /// Interaction logic for StandardPatternsUserControl.xaml
    /// </summary>
    public partial class PatternsUserControl : UserControl
    {
        public ConventionSet Conventions;
        public MainWindow mWindow;

        public PatternsUserControl(MainWindow window)
        {
            InitializeComponent();
            mWindow = window;
            if (!File.Exists("conventions.dat"))
            {
                Conventions = new ConventionSet();
                DataSerializer.SerializeData("conventions.dat", Conventions);
            }
            else
                Conventions = DataSerializer.DeserializeItem("conventions.dat");
            ReloadConventions();
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
                Conventions.Conventions.Add(conv);
                DataSerializer.SerializeData("conventions.dat", Conventions);
                ReloadConventions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReloadConventions()
        {
            dataGridPatterns.Items.Clear();
            foreach (var cv in Conventions.Conventions)
            {
                dataGridPatterns.Items.Add(cv);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Conventions.Conventions.RemoveAt(dataGridPatterns.SelectedIndex);
            ReloadConventions();
            DataSerializer.SerializeData("conventions.dat", Conventions);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Convention currentConvention = Conventions.Conventions[dataGridPatterns.SelectedIndex];
            for (int i = 0; i < mWindow.Structure.Tables.Count; i++)
            {
                mWindow.Structure.Tables[i].Rename(
                    currentConvention.GetTableName(mWindow.Structure.Tables[i].Name),
                    mWindow.Structure.Connection);
                mWindow.Structure.Tables[i].Name = currentConvention.GetTableName(mWindow.Structure.Tables[i].Name);
                string qs = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1 AND TABLE_NAME = '" + mWindow.Structure.Tables[i].Name + "'";
                SqlCommand comm = new SqlCommand(qs, mWindow.Structure.Connection);
                string colName = comm.ExecuteScalar().ToString();

                mWindow.Structure.Tables[i].RenameColumnPK(
                    currentConvention.GetPrimaryKeyName(colName, mWindow.Structure.Tables[i].Name),
                    mWindow.Structure.Connection);
             
                for(int j = 0; j< mWindow.Structure.Tables[i].Columns.Count; j++)
                {
                    mWindow.Structure.Tables[i].RenameColumn(
                        mWindow.Structure.Tables[i].Columns[j],
                        currentConvention.GetColumnName(mWindow.Structure.Tables[i].Columns[j].Name, mWindow.Structure.Tables[i].Name),
                        mWindow.Structure.Connection);
                }   
            }

        }
    }
}
