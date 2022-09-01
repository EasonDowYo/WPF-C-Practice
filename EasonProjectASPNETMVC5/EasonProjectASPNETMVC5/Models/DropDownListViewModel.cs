using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
namespace EasonProjectASPNETMVC5.Models
{
    public class DropDownListViewModel
    {
        public int DDL_ID { get; set; }

        public List<SelectListItem> DDL_List { get; set; }

    }
}