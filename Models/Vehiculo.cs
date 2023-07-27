using System;
using System.Collections.Generic;

#nullable disable

namespace RentaCarApi.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Reservaciones = new HashSet<Reservacione>();
        }

        public int Idvehiculo { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public int GarajeId { get; set; }
        public string Estado { get; set; }

        public virtual Garaje Garaje { get; set; }
        public virtual ICollection<Reservacione> Reservaciones { get; set; }
    }
}
