using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Childcare.Models
{
    public class AllUsers
    {
        [Key]
        public string userid { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public class UsersDBContext : DbContext
        {
            public DbSet<AllUsers> Users { get; set; }
            //public IEnumerable<college> Colleges { get; set; }
        }
    }
}