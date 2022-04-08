using System;
using System.Data;
namespace SQL_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SQLClass sQLClass = new SQLClass();
            DataTable dt = new DataTable();
            string SqlString = "select * from Spend_db.dbo.Spend_Table";

            dt=sQLClass.DoQuery(SqlString);

            Console.WriteLine(dt.Rows[0]["item_name"].ToString());
            Console.ReadKey();
        }
    }
}
