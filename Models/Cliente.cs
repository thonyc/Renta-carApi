using System;
using System.Collections.Generic;

#nullable disable

namespace RentaCarApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        public int Idcliente { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
