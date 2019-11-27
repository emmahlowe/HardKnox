using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HardKnock.Models
{
    [Table("Majors")]
    public class Majors
    {
        [Key]
        [Required(ErrorMessage = "Major ID is required")]
        [StringLength(2)]
        [DisplayName("Major ID")]
        public string Major_ID { get; set; }

        [Required(ErrorMessage = "Major Description is required")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "The length needs to be between 4 and 30")]
        [DisplayName("Major Description")]
        public string Major_Description { get; set; }
    }
}