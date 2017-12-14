using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace is402project2.Models
{
    [Table("questions")]
    public class questions
    {
        [Key]
        public int questionID { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}