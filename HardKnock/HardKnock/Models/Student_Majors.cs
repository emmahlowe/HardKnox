using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HardKnock.Models
{
    public class Student_Majors
    {
        [Key]
        public int Student_ID { get; set; }
        public string Student_FirstName { get; set; }
        public string Student_LastName { get; set; }
        public DateTime Student_EnrollmentDate { get; set; }
        public Decimal? Student_GPA { get; set; }
        public string Major_ID { get; set; }
        public string Major_Description { get; set; }
    }
}