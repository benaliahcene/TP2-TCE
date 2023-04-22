using Microsoft.EntityFrameworkCore;

namespace EC_MicroServicesUser
{
    public class Service_UserDbContext : DbContext
    {
    
    



        public DbSet<EC_MicroServicesUser.Models.User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder DbContextOptionsBuilder)
        {
            string connection_string = "Data Source=DESKTOP-4MISVQS\\SQLEXPRESS02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string database_TP = "ec_user_db";
            DbContextOptionsBuilder.UseSqlServer($"{connection_string};Database={database_TP}; ");
        }
    }
}

