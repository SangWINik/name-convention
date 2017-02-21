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
        }
    }
}
