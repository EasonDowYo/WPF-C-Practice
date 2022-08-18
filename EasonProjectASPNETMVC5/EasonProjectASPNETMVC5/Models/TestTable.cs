namespace EasonProjectASPNETMVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Bind(Include = "ID,SerialNumber,rDateTime,Station,Value1,Value2,Result")]
    [Table("TestTable")]
    [MetadataType(typeof(TestTableItemAttributes))]
    public partial class TestTable
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public DateTime rDateTime { get; set; }
        public string Station { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public bool Result { get; set; }
    }
}
