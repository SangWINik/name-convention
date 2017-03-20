using NameConvention.db_features;
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

namespace NameConvention
{
    /// <summary>
    /// Interaction logic for TableUserControl.xaml
    /// </summary>
    public partial class TableUserControl : UserControl
    {
        DbStructure structure;

        public TableUserControl(DbStructure _structure)
        {
            InitializeComponent();
            structure = _structure;

            for (int i = 0; i < structure.Tables.Count; i++)
                ListTables.Items.Add(structure.Tables[i].Name);
            labelName.Content = "База даних: " + structure.DataBaseName;
        }

        private void ListTables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListColums.UnselectAll();
            textBoxChanged.Text = "";
            gridChanged.Visibility = Visibility.Hidden;

            if (!ListColums.Items.IsEmpty) ListColums.Items.Clear();
            int index = ListTables.SelectedIndex;
            if(index != -1)
                for (int i = 0; i < structure.Tables[index].Columns.Count; i++)
                    ListColums.Items.Add(structure.Tables[index].Columns[i].Name);
        }

        private void ListColums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridChanged.Visibility = Visibility.Visible;
            if(ListColums.SelectedIndex != -1)
                textBoxChanged.Text = structure.Tables[ListTables.SelectedIndex].Columns[ListColums.SelectedIndex].Name;
        }

        private void buttonChanged_Click(object sender, RoutedEventArgs e)
        {
            int index_table = ListTables.SelectedIndex;
            int index_column = ListColums.SelectedIndex;
            structure.Tables[index_table].RenameColumn(structure.Tables[index_table].Columns[index_column],
                textBoxChanged.Text, structure.Connection);
            //ListColums.Items[index_column] = textBoxChanged.Text;
            ListTables.UnselectAll();
            ListColums.UnselectAll();
            ListTables.Items.Clear();
            ListColums.Items.Clear();
            structure.FillStructure(structure.Connection);
            for (int i = 0; i < structure.Tables.Count; i++)
                ListTables.Items.Add(structure.Tables[i].Name);
            labelName.Content = "База даних: " + structure.DataBaseName;
            ListTables.SelectedIndex = index_table;
            ListColums.SelectedIndex = index_column;

        }
    }
}
