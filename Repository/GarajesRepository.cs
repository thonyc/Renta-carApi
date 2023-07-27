using RentaCarApi.Models;
using RentaCarApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.Repository
{
    public class GarajesRepository : IGarajeRepository
    {
        private readonly RentaCarContext  _db;
        public GarajesRepository(RentaCarContext db)
        {
            _db = db;
        }


        public bool ExistGarage(string desc)
        {
            return _db.Garajes.Any(g => g.Descripcion == desc);
        }

        //method used to get all garages
        public ICollection<Garaje> GetGarages()
        {
            return (from g in _db.Garajes where g.Estado == "ACTIVE" select g).ToList();
        }
        //method used to get a exist garage
        public Garaje GetGarage(int id)
        {
            return _db.Garajes.FirstOrDefault(g => g.Idgaraje == id);
        }

        //method used to create a new garage
        public bool CreateGarage(Garaje g)
        {
            g.Estado = "ACTIVE";
            _db.Add(g);
            return Save();
        }

        //method used to update a garage
        public bool UpdateGaraje(Garaje g)
        {
            g.Estado = "ACTIVE";
            _db.Update(g);
            return Save();
        }

        //method used to delete a garage
        public bool DeleteGarage(Garaje g)
        {
            g.Estado = "INACTIVE";
            _db.Update(g);
            return Save();
        }
        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

    }
}
