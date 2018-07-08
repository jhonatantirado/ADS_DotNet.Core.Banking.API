CREATE TABLE `transdetalle` (
  `id_trans` bigint(20) NOT NULL AUTO_INCREMENT,
  `numb_origen` varchar(50) NOT NULL,
  `numb_destino` varchar(50) NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  `fecha` date NOT NULL,
  `customer_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id_trans`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;