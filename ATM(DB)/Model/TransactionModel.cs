using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM_DB_.Model
{
    [Table("Tbl_Transaction")]
    public class TransactionModel
    {
        [Key]
        public int? TransactionID { get; set; }

        public Guid? UserId { get; set; }

        public string TransactionType { get; set; } = null!;

        public decimal TransactionAmount { get; set; }
        public DateTime CreatedDate { get; set; } =DateTime.Now;

    }
}
