using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Childcare.Models
{
    [Table("ChildDay")]
    public class ChildDay
    {
        
        [Key]
        [Column(Order =1)]
        [ForeignKey("Child")]
        [Required]
        //[Display(Name = "Child Id")]
        public Int16 childid { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        [Display(Name = "Day")]
        public Days? Day { get; set; }
        public virtual Child Child { get; set; }
       
    }

    public enum Days
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5
    }
}