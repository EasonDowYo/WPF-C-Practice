using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EasonProjectASPNETMVC5.Models
{
    public partial class MyTestDB2Context : DbContext
    {
        public MyTestDB2Context()
            : base("name=MyTestDB2Context")
        {
        }

        public virtual DbSet<DepartmentTable> DepartmentTables { get; set; }
        public virtual DbSet<StudentTable> StudentTables { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentTable>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<DepartmentTable>()
                .Property(e => e.College)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTable>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<StudentTable>()
                .Property(e => e.StudentName)
                .IsFixedLength();
        }
    }
}
