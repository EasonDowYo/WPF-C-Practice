using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasonProjectASPNETMVC5.Models.Repository
{
    interface ITestTableRepository
    {
        IQueryable<Models.TestTable> ListAllData();

        Models.TestTable GetDataByID(int id);

        IQueryable<Models.TestTable> GetDataBySerialNumber(string sn);

        bool AddData(Models.TestTable testTable);

        bool DeleteData(int id);

        //void DB_Dispose();
    }
}
