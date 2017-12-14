using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace is402project2.Models
{
    [Table("volunteer")]
    public class volunteer
        {
            [Key]
            public int volunteerID { get; set; }
            public String volunteerFirstName { get; set; }
            public String volunteerLastName { get; set; }

        }
}