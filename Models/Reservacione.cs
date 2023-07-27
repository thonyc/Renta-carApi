using System;
using System.Collections.Generic;

#nullable disable

namespace RentaCarApi.Models
{
    public partial class Reservacione
    {
        public Reservacione()
        {
            Alquilers = new HashSet<Alquiler>();
        }

        public int Idreservacion { get; set; }
        public DateTime FechaReservacion { get; set; }
        public int ClienteId { get; set; }
        public string Estado { get; set; }
        public int VehiculoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual ICollection<Alquiler> Alquilers { get; set; }
    }
}
