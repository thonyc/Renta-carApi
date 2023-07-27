using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.Models.Dtos
{
    public class DtoVehiculo
    {

        public int Idvehiculo { get; set; }
        [Required(ErrorMessage = "La matricula es requerida")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "La marca es requerida")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "El color es requerido")]
        public string Color { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        public decimal PrecioAlquiler { get; set; }
        [Required(ErrorMessage = "El garaje es requerido")]
        public int GarajeId { get; set; }
    }
}
