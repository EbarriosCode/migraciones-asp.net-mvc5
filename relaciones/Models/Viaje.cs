using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace relaciones.Models
{
    public class Viaje
    {
        public int IdViaje { get; set; }
        public int IdCliente { get; set; }

        [Required]
        public string Vendio { get; set; }

        [Required]
        public decimal Cobro { get; set; }

        public virtual Clientes Cliente { get; set; }
    }
}