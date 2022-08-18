using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasonProjectASPNETMVC5.Models.Repository
{
    public class TestTableRepository : ITestTableRepository,IDisposable
    {
        public MyTestDBContext myTestDBContext = new MyTestDBContext();
        private bool disposedValue;

        public bool AddData(TestTable testTable)
        {
            try
            {
                myTestDBContext.TestTables.Add(testTable);
                myTestDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteData(int id)
        {
            try
            {
                Models.TestTable tb = myTestDBContext.TestTables.Find(id);
                myTestDBContext.TestTables.Remove(tb);
                myTestDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TestTable GetDataByID(int id)
        {
            return myTestDBContext.TestTables.Find(id);
        }

        public IQueryable<TestTable> GetDataBySerialNumber(string sn)
        {
            return myTestDBContext.TestTables.Where(o => o.SerialNumber.Contains(sn));
        }

        public IQueryable<TestTable> ListAllData()
        {
            return myTestDBContext.TestTables;
        }

        public void DB_Dispose()
        {
            myTestDBContext.Dispose();
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置受控狀態 (受控物件)
                    myTestDBContext.Dispose();//自己加
                }

                // TODO: 釋出非受控資源 (非受控物件) 並覆寫完成項
                // TODO: 將大型欄位設為 Null
                disposedValue = true;
            }
        }

        // // TODO: 僅有當 'Dispose(bool disposing)' 具有會釋出非受控資源的程式碼時，才覆寫完成項
        // ~TestTableRepository()
        // {
        //     // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 請勿變更此程式碼。請將清除程式碼放入 'Dispose(bool disposing)' 方法
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        myTestDBContext.Dispose();
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}


    }
}