

namespace Transactions.domain.entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TransDetalle")]
    public class TransDetalle
    {
        [Key]
        [Column("id_trans", TypeName = "BIGINT")]
        public long id_trans { get; set; }
    

        [Required]
        [Column("numb_origen", TypeName = "VARCHAR(50)")]
        public string numb_origen { get; set; } 

        [Required]
        [Column("numb_destino", TypeName = "VARCHAR(50)")]
        public string numb_destino { get; set; } 

        [Required]
        [Column("monto", TypeName = "DECIMAL(10,2)")]
        public decimal monto { get; set; }

        [Column("fecha", TypeName = "DATETIME")]
        public DateTime fecha { get; set; } 

        [Required ]
        [Column("customer_id", TypeName = "BIGINT")]
        public long customer_id { get; set; } 

    }
}
