using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM_DB_.Model
{
    [Table("Tbl_Users")]
    public class UsersModel
    {
        [Key]
        [Column("UserId")]
        public Guid? UserId { get; set; }

        [Column("Password")]
        public string Password { get; set; } = null!;

        [Column("UserName")]
        public string UserName { get; set; } = null!;

        [Column("AccountNo")]
        public string AccountNo { get; set; } = null!;

        [Column("Amount")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsLocked { get; set; } = false;
    }
}
