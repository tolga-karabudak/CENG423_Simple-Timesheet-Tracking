using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=aybavtr.mssql.somee.com;packet size=4096;user id=noctustest1_SQLLogin_1;pwd=nfyhx8fn54;data source=aybavtr.mssql.somee.com;persist security info=False;initial catalog=aybavtr");
        }



        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }



    }
}
