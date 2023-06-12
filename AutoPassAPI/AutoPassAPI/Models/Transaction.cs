using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPassAPI.Models
{
    [Table("transactions")]
    public class Transaction
    {
        [Column("id")]
        public ulong Id { get; set; }
        [Column("card_id")]
        public ulong CardId { get; set; }
        [Column("transaction_value")]
        public double TransactionValue { get; set; }
        [Column("payment_type")]
        public string PaymentType { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
