using System;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;

namespace DataTable_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Build a DataTable
            System.Data.DataTable dt = new System.Data.DataTable("MyTableName");


            // Build  DataColumn
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StudentID";
            DataColumn dc2 = new DataColumn("StudentName", typeof(string));

            dt.Columns.Add(dc);
            dt.Columns.Add(dc2);
            dt.Columns.Add("Data", typeof(DateTime));

            foreach (DataColumn dcc in dt.Columns)
            {
                Console.WriteLine(dcc.ColumnName);
            }


            // Build  DataRow
            DataRow dr = dt.NewRow();

            dr[0] = "1111";
            dr[1] = "Sam";
            dr[2] = DateTime.Now;

            dt.Rows.Add(dr);
            dt.Rows.Add("2222", "William", DateTime.Now.AddHours(-6));
            dt.Rows.Add("3333", "Eason", DateTime.Now.AddHours(-12));

            foreach (DataRow drr in dt.Rows)
            {
                Console.WriteLine(drr[0]);
                Console.WriteLine(drr[0].ToString() + drr["StudentName"].ToString() + drr[2].ToString());
            }
            for(int i=0; i<dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);// Output StudentID
            }

            // 建立工作簿
            IWorkbook wb = new XSSFWorkbook();

            // .xls
            // IWorkbook wb = new HSSFWorkbook();

            using (FileStream fs = File.Create($@"D:\test.xlsx"))
            {
                // 建立名為 Simple 的工作表
                ISheet sheet = wb.CreateSheet("Simple");

                int i = 0;
                int j = 0;

                #region Title

                // 建立新的 row 給標題用
                sheet.CreateRow(0);

                for (i = 0; i < dt.Columns.Count; i++)
                {
                    // 取得已建立的 row ，再建立 cell，最後再配置值給 cell
                    sheet.GetRow(0).CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }

                #endregion

                #region Content

                // 走訪 dt
                for (i = 1; i <= dt.Rows.Count; i++)
                {
                    sheet.CreateRow(i);

                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        // 因為建立過的 row 或 cell 再次建立會覆蓋原有的值，所以建立過的物件使用 Get 取得再設置 Value
                        sheet.GetRow(i).CreateCell(j).SetCellValue(dt.Rows[i - 1][j].ToString());
                    }
                }
                #endregion

                // 將 wb 寫出到檔案流
                wb.Write(fs);

                // 釋放資源
                wb.Close();
                wb = null;
                sheet = null;
            }



            int iii = 1;
        }
        
    }
    
}
