

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
        //BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,

        [Required]
        [Column("numb_origen", TypeName = "VARCHAR(50)")]
        public string numb_origen { get; set; } // VARCHAR(50)  NOT NULL,

        [Required]
        [Column("numb_destino", TypeName = "VARCHAR(50)")]
        public string numb_destino { get; set; } //VARCHAR(50)  NOT NULL,

        [Required]
        [Column("monto", TypeName = "DECIMAL(10,2)")]
        public decimal monto { get; set; } // DECIMAL(10,2)  NOT NULL,

        [Column("fecha", TypeName = "DATE")]
        public DateTime fecha { get; set; } // DATETIME NULL,

        [Required ]
        [Column("customer_id", TypeName = "BIGINT")]
        public long customer_id { get; set; } // BIGINT UNSIGNED NOT NULL,


        //FOREIGN KEY(customer_id) REFERENCES customer(customer_id)

    }
}
