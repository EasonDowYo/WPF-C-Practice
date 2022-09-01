using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasonProjectASPNETMVC5.Models.ModelDropDownList
{
    public class MyTestDBDropDownList
    {
        public SelectList GetDepartmentList()
        {
            using (MyTestDB2Context _db = new MyTestDB2Context())
            {
                var dt = _db.DepartmentTables.ToList();
                SelectList listItems = new SelectList(dt, "DepartmentId", "DepartmentName");
                return listItems;
            }
        }

    }
}