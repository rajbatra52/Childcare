using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace Childcare.Models
{
    [Table("ChildGuardian")]
    public class ChildGuardian
    {
        [Key]
        [Required]
        [Column(Order=1)]
        [ForeignKey("Child")]
        [Display(Name = "Child Id")]
        public Int16 childid { get; set;}
        [Key]
        [Required]
        [Column(Order = 2)]
        [ForeignKey("Guardian")]
        [Display(Name = "Guardian Id")]
        public Int16 guardianid { get; set; }

        public virtual Child Child { get; set; }
        public virtual Guardian Guardian { get; set; }

        public IEnumerable<ChildGuardian> ChildGuardians { get; set; }
    }
}