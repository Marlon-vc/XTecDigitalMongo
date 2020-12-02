using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XTecDigitalMongo.Helpers;
using XTecDigitalMongo.Models;
using XTecDigitalMongo.Services;

namespace XTecDigitalMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly EstudianteService _service;

        public EstudiantesController(EstudianteService service)
        {
            _service = service;
        }

        // GET: api/<EstudiantesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{carnet}")]
        public IActionResult Get(string carnet)
        {
            var estudiante = _service.Get(carnet);

            if (estudiante == null)
                return NotFound();
            
            return Ok(estudiante);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public IActionResult Post(Estudiante estudiante)
        {
            if (EstudianteExists(estudiante.Carnet))
                return Conflict();
            
            estudiante.Pass = Encryption.Md5(estudiante.Pass);
            _service.Create(estudiante);

            return CreatedAtRoute("Default", new { carnet = estudiante.Carnet}, estudiante);
        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{carnet}")]
        public IActionResult Put(string carnet, Estudiante estudiante)
        {
            if (carnet != estudiante.Carnet)
                return BadRequest();

            if (!EstudianteExists(carnet))
                return NotFound();
            
            _service.Update(carnet, estudiante);
            return Ok(estudiante);
        }

        // DELETE api/<EstudiantesController>/password/5
        [HttpPut("password/{carnet}")]
        public IActionResult PutPassword(string carnet, Estudiante estudiante)
        {
            if (estudiante.Carnet != carnet)
                return BadRequest();

            if (!EstudianteExists(carnet))
                return NotFound();

            estudiante.Pass = Encryption.Md5(estudiante.Pass);
            _service.Update(carnet, estudiante);

            return Ok(estudiante);
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{carnet}")]
        public IActionResult Delete(string carnet)
        {
            if (!EstudianteExists(carnet))
                return NotFound();

            _service.Remove(carnet);
            return Ok();
        }

        public bool EstudianteExists(string carnet)
        {
            return _service.Get(carnet) != null;
        }
    }
}
