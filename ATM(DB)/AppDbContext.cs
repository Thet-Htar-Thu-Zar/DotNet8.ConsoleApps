using ATM_DB_.Model;
using Microsoft.EntityFrameworkCore;

namespace ATM_DB_
{
    public partial class AppDbContext : DbContext
    {     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=192.168.0.184;Initial Catalog=Thet_Htar_Thu_Zar;User ID=thetys;Password=P@ssw0rd;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public virtual DbSet<UsersModel> TblUsers { get; set; }
        public virtual DbSet<TransactionModel> TblTransactions { get; set; }
        
    }
}
