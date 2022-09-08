namespace EasonProjectASPNETMVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentTable")]
    public partial class StudentTable
    {
        [Key]
        public int StudentID { get; set; }

        [DataType(DataType.Date)]
        public DateTime AdmisstionDate { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public int? Age { get; set; }

        public int? DepartmentID { get; set; }

        [Required]
        [StringLength(10)]
        public string StudentName { get; set; }

        public virtual DepartmentTable DepartmentTable { get; set; }

        public bool IsInschool { get; set; }

        [StringLength(1)]
        public string Sex { get; set; }
        //public SexList Sex { get; set; }
        public enum SexList
        {
            [Display(Name ="³ä³ä")]
            M,
            [Display(Name = "¤k¤k")]
            F
        }
    }
}
