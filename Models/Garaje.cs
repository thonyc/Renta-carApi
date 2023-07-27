using System;
using System.Collections.Generic;

#nullable disable

namespace RentaCarApi.Models
{
    public partial class Garaje
    {
        public int Idgaraje { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
    }
}
