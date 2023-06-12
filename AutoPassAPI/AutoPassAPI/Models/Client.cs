using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPassAPI.Models
{
    [Table("clients")]
    public class Client
    {
        [Column("id")]
        public ulong Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("cpf")]
        public string CPF { get; set; }
        [Column("birthday")]
        public DateTime Birthday { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("modified")]
        public DateTime? Modified { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
    }
}
