using System;
using System.Data;
using System.Drawing;
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

            SimpleExport(dt, $@"D:\test2.xlsx");

            int iii = 1;
        }
        static void SimpleExport(DataTable dt, string path)
        {
            // 建立工作簿
            IWorkbook wb = new XSSFWorkbook();
            // .xls
            // IWorkbook wb = new HSSFWorkbook();
            using (FileStream fs = File.Create(path))
            {
                // 建立名為 Simple 的工作表
                ISheet sheet = wb.CreateSheet("Simple");
                int i = 0, j = 0;

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

                #region Layouts

                // 指定列印紙張大小
                //sheet.PrintSetup.PaperSize = (short)PaperSize.A4;

                // 列印版面為 橫向: true 直向: false
                //sheet.PrintSetup.Landscape = true;

                // 設置列印標題（上側）
                //int firstRow = 0;
                //int lastRow = 0;
                //int firstCol = 0;
                //int lastCol = dt.Columns.Count;
                //sheet.RepeatingRows = new CellRangeAddress(firstRow, lastRow, firstCol, lastCol);

                // 設置列印標題（左側）
                //sheet.RepeatingColumns = new CellRangeAddress(firstRow, lastRow, firstCol, lastCol);

                // 列印頁尾頁碼
                //sheet.Footer.Center = "&P";

                // 顯示格線 顯示: true 不顯示: false
                //sheet.DisplayGridlines = true;

                // 調整欄寬
                //sheet.SetColumnWidth(0, 20 * 256);

                // 自動調整欄寬
                for (i = 1; i < dt.Columns.Count; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                // 設置行高
                sheet.GetRow(0).Height = 30 * 20;

                // 合併儲存格
                //CellRangeAddress region = new CellRangeAddress(0, 2, 1, 1);
                //sheet.AddMergedRegion(region);

                #endregion

                #region Font

                XSSFFont font = (XSSFFont)wb.CreateFont();

                // 字體樣式
                font.FontName = "Arial";

                // 字體顏色
                font.SetColor(new XSSFColor(Color.Blue));

                // 粗體
                font.IsBold = true;

                // 斜體
                font.IsItalic = true;

                // 刪除線
                font.IsStrikeout = true;

                // 字體大小
                font.FontHeightInPoints = 20;

                #endregion

                #region Style

                XSSFCellStyle style = (XSSFCellStyle)wb.CreateCellStyle();

                // 多行文字(自動換行)
                style.WrapText = true;

                // 文字水平置中
                style.Alignment = HorizontalAlignment.Center;

                // 文字垂直置中
                style.VerticalAlignment = VerticalAlignment.Center;

                // 背景色
                style.FillForegroundColor = new XSSFColor(Color.Red).Index;

                // 背景色樣式
                style.FillPattern = FillPattern.SparseDots;

                // 上框線樣式
                style.BorderTop = BorderStyle.DashDot;

                // 下框線樣式
                style.BorderBottom = BorderStyle.Double;

                // 左框線樣式
                style.BorderLeft = BorderStyle.Hair;

                // 右框線樣式
                style.BorderRight = BorderStyle.Thick;

                // 上框線顏色
                style.TopBorderColor = new XSSFColor(Color.Chocolate).Index;

                // 下框線顏色
                style.BottomBorderColor = new XSSFColor(Color.DarkOrange).Index;

                // 左框線顏色
                style.LeftBorderColor = new XSSFColor(Color.Pink).Index;

                // 右框線顏色
                style.RightBorderColor = new XSSFColor(Color.Purple).Index;

                #endregion

                // 凍結頂端列
                sheet.CreateFreezePane(0, 1, 0, 1);

                // 凍結左欄
                sheet.CreateFreezePane(1, 0, 1, 0);

                style.SetFont(font);

                for (i = 1; i < dt.Columns.Count; i++)
                {
                    sheet.GetRow(0).GetCell(i).CellStyle = style;
                }

                // 將 wb 寫出到檔案流
                wb.Write(fs);

                // 釋放資源
                wb.Close();
                wb = null;
                sheet = null;
            }
        }
    }
    
}
