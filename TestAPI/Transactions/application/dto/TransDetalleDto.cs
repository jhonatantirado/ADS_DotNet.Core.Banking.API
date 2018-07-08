namespace Transactions.application.dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class TransDetalleDto
    {

        public long id_trans { get; set; }

        public string numb_origen { get; set; }

        public string numb_destino { get; set; }

        public decimal monto { get; set; }

        public DateTime fecha { get; set; }

        public long customer_id { get; set; }

    }
}
