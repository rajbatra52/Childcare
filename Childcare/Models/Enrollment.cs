using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Childcare.Models
{
    [Table("Enrollment")]
    public class Enrollment
    {
       
        [Required]
        [Display(Name = "Enrollment Id")]
        public Int16 enrollmentid { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Enrollment Date")]
        public DateTime enrollmentdate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Enrollment From")]
        public DateTime enrollmentfrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="{0} field is required")]
        [Display(Name = "Enrollment To")]
        public DateTime enrollmentto { get; set; }
        [ForeignKey("Child")]
        //[Display(Name = "Child Id")]
        public UInt16 childid { get; set; }
        //Navigation property
        public virtual Child Child { get; set; }
    }
}