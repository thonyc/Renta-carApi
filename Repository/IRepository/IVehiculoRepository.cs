using RentaCarApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.Repository.IRepository
{
   public  interface IVehiculoRepository
    {
        ICollection<Vehiculo> GetVehiculos();

        Vehiculo GetVehiculo(int id);
        bool CreateVehiculo(Vehiculo v);
        bool UpdateVehiculo(Vehiculo v);

        bool DeleteVehiculo(Vehiculo v);

        bool ExistVehiculo(string matricula);
        bool ExisteVehiculoGaraje(int garaje);
        bool Save();
    }
}
