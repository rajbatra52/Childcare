using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Childcare.Models
{
    [Table("Child")]
    public class Child
    {
        
        [Required]
        [Column(Order = 1)]
        [Display(Name = "Child Id")]
        public Int16 childid { get; set; }
        [Display(Name = "Child Name")]
        [Required]
        [StringLength(30, ErrorMessage = "The child name can not exceed more than 30 characters")]
        public string childname { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Child DOB")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime childdob { get; set; }
        [Display(Name = "Child Address")]
        [Required]
        public string childaddress { get; set; }
        [Display(Name = "Child Gender")]
        [Required]
        public Gender childgender { get; set; }
       

        public class ChildDBContext : DbContext
        {
            public DbSet<Child> Children { get; set; }
            //public IEnumerable<college> Colleges { get; set; }
        }
        public enum Gender
        {
            Male=1,
            Female=2
        }

    }
}