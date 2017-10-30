using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Childcare.Models
{
    [Table("Guardian")]
    public class Guardian
    {
        [Required, Display(Name = "Guardian Id:")]
       
        public Int16 guardianid { get; set; }
        [Display(Name = "Guardian Name")]
        [Required]
        [StringLength(30, ErrorMessage = "The {0} can not exceed more than 30 characters")]
        public string guardianname { get; set; }
       
        [Required, Display(Name = "Guardian Relationship"), StringLength(1, ErrorMessage = "The {0} can not exceed more than 1 character")]
        
        public string guardianrelationship { get; set; }
        [Display(Name = "Guardian Age")]
        [Required]
        
        public Int16? guardianage { get; set; } 
        [Display(Name = "Guardian Address:")]
        [Required]
        [StringLength(40)]
        public string guardianaddress { get; set; }
        [Display(Name = "Guardian Gender:")]
        [Required]
        [StringLength(1)]
        public string guardiangender { get; set; }
        public List<Gen> GenderList { get; set; }

        //public string guardiangender { get; set; }
        [Display(Name = "Guardian Mobile:")]
        [Required]
        [StringLength(15)]
        public string guardianmobile { get; set; }
        [Display(Name = "Guardian Phone:")]
        [Required]
        [StringLength(15)]
        public string guardianphone { get; set; }
        [Display(Name = "Guardian Emergency Contact:")]
        [Required]
        [StringLength(30)]
        public string guardianemergencycontact { get; set; }

        public class GuardianDBContext : DbContext
        {
            public DbSet<Guardian> Guardians { get; set; }
            //public IEnumerable<college> Colleges { get; set; }
        }

        //public Guardian()
        //{
        //    GenderList = new List<Gen>
        //        {
        //            new Gen { ID="1", Type="Male" },
        //             new Gen { ID="2", Type="female" }
        //        };
        //}  
    }
    public class Gen
    {
        public string ID { get; set; }
        public string Type { get; set; }
    }
}