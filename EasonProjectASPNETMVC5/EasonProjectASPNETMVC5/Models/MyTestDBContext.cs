using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EasonProjectASPNETMVC5.Models
{
    public partial class MyTestDBContext : DbContext
    {
        public MyTestDBContext()
            : base("name=MyTestDB_ConnectString")
        {
        }

        public virtual DbSet<TestTable> TestTables { get; set; }//Change varialbe name to "TestTables" from "TestTable"

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestTable>()
                .Property(e => e.SerialNumber)
                .IsFixedLength();

            modelBuilder.Entity<TestTable>()
                .Property(e => e.Station)
                .IsFixedLength();
        }
    }
}
