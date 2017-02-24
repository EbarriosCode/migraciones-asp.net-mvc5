using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace relaciones.Models
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}