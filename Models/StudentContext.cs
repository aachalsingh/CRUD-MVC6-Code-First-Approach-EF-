using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EF_CodeFirstApproach.Models
{
    public class StudentContext : DbContext
    {
        //strudent context class , to store in table
        public DbSet<Student> Stu { get; set; }    //dbset stores data in database
    }
}