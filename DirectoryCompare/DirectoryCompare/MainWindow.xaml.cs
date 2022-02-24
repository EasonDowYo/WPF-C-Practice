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

using System.IO;

namespace DirectoryCompare
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var i = TreeView1.Items;
            int h = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] dirs = Directory.GetDirectories(@"C:\Users\USER\Downloads\Folder");
            foreach(string main_dir in dirs)
            {
                Console.WriteLine(main_dir);
                foreach (string sub_dir in Directory.GetDirectories(main_dir))
                {
                    Console.WriteLine("\t"+ sub_dir);
                    foreach (string filename in Directory.GetFiles(sub_dir))
                    {
                        Console.WriteLine("\t\t >" + filename);
                    }
                }
            }
        }
    }
}
