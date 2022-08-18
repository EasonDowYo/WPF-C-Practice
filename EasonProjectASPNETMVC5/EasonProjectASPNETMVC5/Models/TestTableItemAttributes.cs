using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EasonProjectASPNETMVC5.Models
{
    public class TestTableItemAttributes
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "需要輸入(這是自己寫的錯誤訊息)")]
        [Display(Name = "SerialNumber(序號)(必填)")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "{0}，至少要有 {2} 個字（最長允許 {1} 個字）")]
        public string SerialNumber { get; set; }

        [Display(Name = "這是日期啦")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [MyValidation.MyDateRangeValidation(startDate ="2020/1/1" , endDate = "2023/1/1" ,ErrorMessage="my日期輸入錯誤")]
        public DateTime rDateTime { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "這是自己寫的錯誤訊息")]
        public string Station { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public bool Result { get; set; }

    }
}