using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace is402project2.Models
{
    [Table("program")]
    public class program
    {
        [Key]
        public int programID { get; set; }
        public string programName { get; set; }
        public string programDay { get; set; }
        public string programTime { get; set; }
        public string participantAge { get; set; }
        public string programDescription { get; set; }

        [ForeignKey("volunteer")]
        public int volunteerID { get; set; }
        [ForeignKey("intern")]
        public int internID { get; set; }
    }
}