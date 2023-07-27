using RentaCarApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.Repository.IRepository
{
    public interface IGarajeRepository
    {
        ICollection<Garaje> GetGarages();

        Garaje GetGarage(int id);
        bool CreateGarage(Garaje g);
        bool UpdateGaraje(Garaje g);

        bool DeleteGarage(Garaje g);
        
        bool ExistGarage(string desc);
        bool Save();
    }
}
