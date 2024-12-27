using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailManagement_DB_.Model
{
    [Table("Tbl_Products")]
    public class ProductModel
    {
        [Key]
        public Guid ProductID { get; set; } = new Guid();
        public string? ProductName { get; set; } = null!;
        public int? RemainingStock { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? ProductProfit { get; set; }
        public bool ActiveFlag { get; set; } = true;
    }
}
