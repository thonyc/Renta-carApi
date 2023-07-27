using RentaCarApi.Models;
using RentaCarApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.Repository
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly RentaCarContext _db;
        public VehiculoRepository(RentaCarContext db)
        {
            _db = db;
        }


        public Vehiculo GetVehiculo(int id)
        {
            return _db.Vehiculos.FirstOrDefault(v => v.Idvehiculo == id);
        }

        public ICollection<Vehiculo> GetVehiculos()
        {
            return (from v in _db.Vehiculos where v.Estado == "ACTIVE" select v).ToList();
        }
        public bool CreateVehiculo(Vehiculo v)
        {
            v.Estado = "ACTIVE";
            _db.Add(v);

            return Save();
        }
        public bool UpdateVehiculo(Vehiculo v)
        {
            v.Estado = "ACTIVE";
            _db.Update(v);

            return Save();
        }

        public bool DeleteVehiculo(Vehiculo v)
        {
            v.Estado = "INACTIVE";
            _db.Update(v);

            return Save();
        }

        public bool ExisteVehiculoGaraje(int garaje)
        {
            return _db.Vehiculos.Any(v => v.GarajeId == garaje);
        }

        public bool ExistVehiculo(string matricula)
        {
            return _db.Vehiculos.Any(v => v.Matricula.Trim().ToUpper() == matricula.Trim().ToUpper());
        }


        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true:false;
        }

    }
}
