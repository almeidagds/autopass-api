using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPassAPI.Models
{
    [Table("cards")]
    public class Card
    {
        [Column("id")]
        public ulong Id { get; set; }
        [Column("card_number")]
        public string CardNumber { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("client_id")]
        public ulong ClientId { get; set; }
        [Column("balance")]
        public double Balance { get; set; }
        [Column("balance_limit")]
        public double BalanceLimit { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("modified")]
        public DateTime? Modified { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
    }
}
