using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasonProjectASPNETMVC5.Models
{
    public class DepartmentStudent2ViewModel
    {
        public DepartmentTable DPTbl { get; set; }
        public IList<StudentTable> SDTbl { get; set; }
    }
}