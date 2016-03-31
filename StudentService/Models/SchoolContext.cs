using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentService.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name= StudentDB") { }
        public DbSet<Student> Students { get; set; }
    }

}