using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HardKnock.Models;

namespace HardKnock.DAL
{
    public class HardKnoxContext : DbContext
    {
        public HardKnoxContext() : base("HardKnoxContext")
        {

        }

        public DbSet<Student_Majors> Students_Major { get; set; }
        public DbSet<Majors> Major { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}