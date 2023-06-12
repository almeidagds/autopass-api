using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPassAPI.Models
{
    [Table("card_types")]
    public class CardType
    {
        [Column("id")]
        public ulong Id { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [Column("modified")]
        public DateTime? Modified { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }

    }
}
