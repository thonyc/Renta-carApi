
using AutoMapper;
using RentaCarApi.Models;
using RentaCarApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.RentaCarsMapper
{
    public class RentaCarMapper : Profile
    {
        public RentaCarMapper()
        {
            CreateMap<Garaje, DtoGaraje>().ReverseMap();
            CreateMap<Vehiculo, DtoVehiculo>().ReverseMap();
        }   
    }
}
