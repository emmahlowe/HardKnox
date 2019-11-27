using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HardKnock.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        [DisplayName("First Name")]
        public string Student_FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        [DisplayName("Last Name")]
        public string Student_LastName { get; set; }

        [Required(ErrorMessage = "Please enter an enrollment date")]
        [DisplayName("Enrollment Date")]
        public DateTime Student_EnrollmentDate { get; set; }

        [DisplayName("GPA")]
        public Decimal? Student_GPA { get; set; }

        [DisplayName("Major")]
        [Required(ErrorMessage = "Please enter a major")]
        public string Major_ID { get; set; }
    }
}