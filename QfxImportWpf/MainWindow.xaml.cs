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
using QfxImport;

namespace QfxImportWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string filePath = Properties.Resources.filePath;
            QfxFileIo io = new QfxFileIo(filePath);
            this.Title = io.AllTransactionsTable.Rows.Count.ToString();
            display.ItemsSource = io.AllTransactionsTable.DefaultView;
        }
    }
}
