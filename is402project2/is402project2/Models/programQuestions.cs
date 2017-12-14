using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace is402project2.Models
{
    public class programQuestions
    {
        public IEnumerable<volunteer> Volunteer { get; set; }
        public program Program { get; set; }
        public IEnumerable<intern> Intern { get; set; }
        public IEnumerable<questions> Questions { get; set; }

    }
}