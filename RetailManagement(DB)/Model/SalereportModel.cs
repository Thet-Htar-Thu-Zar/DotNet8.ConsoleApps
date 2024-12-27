using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailManagement_DB_.Model
{
    [Table("Tbl_SaleReports")]

    public class SalereportModel
    {
        [Key]
        public Guid SaleID { get; set; } = new Guid();
            public Guid ProductID { get; set; }
            public int? QuantitySold { get; set; }
            public decimal? TotalPrice { get; set; }
            public decimal? TotalProfit { get; set; }
            public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
            public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
