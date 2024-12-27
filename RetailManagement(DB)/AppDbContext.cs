using Microsoft.EntityFrameworkCore;
using RetailManagement_DB_.Model;

namespace RetailManagement_DB_
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
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<SalereportModel> Salereports { get; set; }

      
    }
}
