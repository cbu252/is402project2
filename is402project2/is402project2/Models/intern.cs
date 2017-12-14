using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace is402project2.Models
{
    [Table("intern")]
    public class intern
    {
        [Key]
        public int internID { get; set; }
        public string internFirstName { get; set; }
        public string internLastName { get; set; }


    }
}