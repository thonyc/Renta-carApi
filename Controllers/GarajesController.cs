using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentaCarApi.Models;
using RentaCarApi.Models.Dtos;
using RentaCarApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentaCarApi.Controllers
{
    [Route("api/garajes")]
    [ApiController]
    public class GarajesController : ControllerBase
    {
        private readonly IGarajeRepository _gRepo;
        private readonly IMapper _mapper;
        readonly ResponseMessage responseMessage = new ResponseMessage();

        public GarajesController(IGarajeRepository gRepo, IMapper mapper)
        {
            _gRepo = gRepo;
            _mapper = mapper;
        }
        // GET: api/<GarajesController>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _gRepo.GetGarages();
            try
            {
                return Ok(list);

            }
            catch (Exception e)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "Error al obtener todos los garajes registrados.";
                responseMessage.MessageReturned = e.Message;

                return StatusCode(500, responseMessage);
            }
        }


        // POST api/<GarajesController>
        [HttpPost]
        public IActionResult Post([FromBody] DtoGaraje  g)
        {
            if (g == null)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "No se esta enviando la información";
                responseMessage.MessageReturned = "Verificar que se este enviando la información requerida";
                return StatusCode(400, responseMessage);
            }

            if (_gRepo.ExistGarage(g.Descripcion))
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "El garaje que decea registrar ya existe";
                responseMessage.MessageReturned = "Intentar con otro departamento";
                return StatusCode(404, responseMessage);
            }

            try
            {
                var garaje = _mapper.Map<Garaje>(g);
                _gRepo.CreateGarage(garaje);

                responseMessage.Status = "OK";
                responseMessage.Message = $"se agrego el garaje {g.Descripcion}";
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

        // PUT api/<GarajesController>/5
        [HttpPut]
        public IActionResult Update([FromBody] DtoGaraje g)
        {
            if (g == null)
            {
                responseMessage.Status = "Error";
                responseMessage.Message = "No se esta enviando la información";
                responseMessage.MessageReturned = "Verificar que se este enviando la información requerida";
                return StatusCode(400, responseMessage);
            }


            try
            {
                var garaje = _mapper.Map<Garaje>(g);
                _gRepo.UpdateGaraje(garaje);

                responseMessage.Status = "OK";
                responseMessage.Message = $"se agrego el garaje {g.Descripcion}";
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

        // DELETE api/<GarajesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var garage = _gRepo.GetGarage(id);

                _gRepo.DeleteGarage(garage);

                responseMessage.Status = "OK";
                responseMessage.Message = $"se elimino el garaje {garage.Descripcion}";
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
