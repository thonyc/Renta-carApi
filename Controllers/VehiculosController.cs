using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentaCarApi.Models;
using RentaCarApi.Models.Dtos;
using RentaCarApi.Repository;
using RentaCarApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoRepository _vRepo;
        private readonly IMapper mapper;
        readonly ResponseMessage responseMessage = new ResponseMessage();

        public VehiculosController(IVehiculoRepository vRepo, IMapper _mapper)
        {
            _vRepo = vRepo;
            mapper = _mapper;
        }

        // GET: api/<VehiculosController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _vRepo.GetVehiculos();
            try
            {
                return Ok(list);

            }
            catch (Exception e)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "Error al obtener todos los vehiculos registrados.";
                responseMessage.MessageReturned = e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public IActionResult Post([FromBody] DtoVehiculo v)
        {
            if (v == null)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "No se esta enviando la información";
                responseMessage.MessageReturned = "Verificar que se este enviando la información requerida";
                return StatusCode(400, responseMessage);
            }

            if (_vRepo.ExistVehiculo(v.Matricula))
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "El vehiculo que decea registrar ya existe";
                responseMessage.MessageReturned = "Intentar con otro vehiculo";
                return StatusCode(404, responseMessage);
            }

            if (_vRepo.ExisteVehiculoGaraje(v.GarajeId))
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "El garaje que desea asociar ya esta siendo utilizado por otro vehiculo";
                responseMessage.MessageReturned = "Intentar con otro garaje";
                return StatusCode(404, responseMessage);
            }

            try
            {
                var ve = mapper.Map<Vehiculo>(v);
                _vRepo.UpdateVehiculo(ve);

                responseMessage.Status = "OK";
                responseMessage.Message = $"se agrego el vehiculo {ve.Matricula}";
                responseMessage.MessageReturned = "Registro exitoso";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "Error al registrar el garaje.";
                responseMessage.MessageReturned = e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        // PUT api/<VehiculosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] DtoVehiculo v)
        {
            if (v == null)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "No se esta enviando la información";
                responseMessage.MessageReturned = "Verificar que se este enviando la información requerida";
                return StatusCode(400, responseMessage);
            }
            try
            {
                var ve = mapper.Map<Vehiculo>(v);
                _vRepo.UpdateVehiculo(ve);

                responseMessage.Status = "OK";
                responseMessage.Message = $"se actualizo el vehiculo {ve.Matricula}";
                responseMessage.MessageReturned = "Actualizacion exitoso";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "Error al actualizar el vehiculo.";
                responseMessage.MessageReturned = e.Message;

                return StatusCode(500, responseMessage);
            }
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var v = _vRepo.GetVehiculo(id);

                _vRepo.DeleteVehiculo(v);

                responseMessage.Status = "OK";
                responseMessage.Message = $"se elimino el vehiculo {v.Matricula}";
                responseMessage.MessageReturned = "Eliminacion exitosa";

                return Ok(responseMessage);

            }
            catch (Exception e)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "Error al registrar el garaje.";
                responseMessage.MessageReturned = e.Message;

                return StatusCode(500, responseMessage);
            }
        }
    }
}
