using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TimeSheetManagement.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //
            //optionsBuilder.UseSqlServer("workstation id=aybavtr.mssql.somee.com;packet size=4096;user id=noctustest1_SQLLogin_1;pwd=nfyhx8fn54;data source=aybavtr.mssql.somee.com;persist security info=False;initial catalog=aybavtr");
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = Timesheet; Persist Security Info = True; User ID = sa; Password = Timesheet2022; Encrypt = False");
        }
     /*string connectionString = "Data Source = localhost; Initial Catalog = Timesheet; Persist Security Info=True; User ID = sa; Password = Timesheet2022;Encrypt=False";
        SqlConnection connection = new SqlConnection(connectionString);*/

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
       
        
    
    }
}
