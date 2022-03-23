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
            //GetDiractoriesFiles(@"C:\Users\USER\Downloads\Folder", 0);


            CompareDirectoriesFiles(@"C:\Users\USER\Downloads\Folder2", @"C:\Users\USER\Downloads\Folder");

        }


        private void GetDiractoriesFiles(string path,int layer)
        {
            DirectoryInfo DI = new DirectoryInfo(path);
            DirectoryInfo[] DirList = DI.GetDirectories();


            foreach(DirectoryInfo each_dir in DirList)
            {
                for (int i = 0; i < layer; i++)
                    Console.Write("\t");
                Console.WriteLine(each_dir.Name);
                GetDiractoriesFiles(each_dir.FullName, layer+1);
            }

            foreach (FileInfo fi in DI.GetFiles())
            {
                for (int i = 0; i < layer; i++)
                    Console.Write("\t");
                Console.WriteLine(fi.Name);
            }
                
        }

        private void CompareDirectoriesFiles(string path1, string path2)
        {
            DirectoryInfo DI1 = new DirectoryInfo(path1);
            DirectoryInfo DI2 = new DirectoryInfo(path2);
            DirectoryInfo[] DirList1 = DI1.GetDirectories();
            DirectoryInfo[] DirList2 = DI2.GetDirectories();

            FileInfo[] FileList1 = DI1.GetFiles();
            FileInfo[] FileList2 = DI2.GetFiles();

            compare two_item=compare.NotExist;

            //Start compare two directories
            for(int i1=0; i1< DirList1.Count(); i1++)
            {
                for (int i2 = 0; i2 < DirList2.Count(); i2++)
                {
                    if (DirList1[i1].Name == DirList2[i2].Name)
                    {
                        if(DirList1[i1].LastWriteTime== DirList2[i2].LastWriteTime)
                        {
                            two_item = compare.IsSame;
                            Console.WriteLine(DirList1[i1].FullName + " and "+ DirList2[i2].FullName + " is the same");
                            CompareDirectoriesFiles(DirList1[i1].FullName, DirList2[i2].FullName);
                            break;
                        }
                        else
                        {
                            two_item = compare.Different;
                            Console.WriteLine(DirList1[i1].FullName + " is not the same");
                            CompareDirectoriesFiles(DirList1[i1].FullName, DirList2[i2].FullName);
                            break;
                        }
                        
                    }

                }
                if(two_item!=compare.IsSame && two_item != compare.Different)
                {
                    two_item = compare.NotExist;
                    Console.WriteLine(DirList1[i1].FullName + " is not the exist in Directory2");
                }
                two_item = compare.NotExist;

            }
            two_item = compare.NotExist;
            //Start compare two files in each directory
            for (int ii=0; ii<FileList1.Count(); ii++)
            {
                for(int jj=0; jj< FileList2.Count(); jj++)
                {
                    if (FileList1[ii].Name == FileList2[jj].Name)
                    {
                        two_item = compare.IsSame;
                        Console.WriteLine(FileList1[ii].FullName + " and " + FileList2[jj].FullName + " is the same");
                        
                        break;
                    }
                    else
                    {
                        two_item = compare.Different;
                        Console.WriteLine(FileList1[ii].FullName + " is not the same");
                        
                        break;
                    }
                }
                if (two_item != compare.IsSame && two_item != compare.Different)
                {
                    two_item = compare.NotExist;
                    Console.WriteLine(FileList1[ii].FullName + " is not the exist in Directory2");
                }
                two_item = compare.NotExist;
            }

        }
        private enum compare
        {
            IsSame,
            Different,
            NotExist
        } 


        private SameIndex GetFirstSameIndex(DirectoryInfo[] D1,DirectoryInfo[] D2)
        {
            SameIndex sameIndex = new SameIndex();
            for (int i = 0; i < D1.Count(); i++)
            {
                for (int j = 0; j < D2.Count(); j++)
                {
                    if (D1[i].Name == D2[j].Name)
                    {
                        sameIndex.DirList1_Idx = i;
                        sameIndex.DirList2_Idx = j;
                    }

                }
            }



            return sameIndex;
        }
        struct SameIndex
        {
            public int DirList1_Idx;
            public int DirList2_Idx;
        }
        private enum dir_file
        {
            Equal,
            Different,
            OneNull
        }
    }
}
