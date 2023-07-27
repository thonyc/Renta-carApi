using System;
using System.Collections.Generic;

#nullable disable

namespace RentaCarApi.Models
{
    public partial class Alquiler
    {
        public int Idalquiler { get; set; }
        public int ReservacionId { get; set; }
        public string Estado { get; set; }
        public string Comentario { get; set; }

        public virtual Reservacione Reservacion { get; set; }
    }
}
