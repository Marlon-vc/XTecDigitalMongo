using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Estudiante> Get()
        {
            return _service.Get();
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{carnet}")]
        public Estudiante Get(string carnet)
        {
            return _service.Get(carnet);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public void Post(Estudiante estudiante)
        {
            _service.Create(estudiante);
        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{carnet}")]
        public void Put(string carnet, Estudiante estudiante)
        {
            _service.Update(carnet, estudiante);
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{carnet}")]
        public void Delete(string carnet)
        {
            _service.Remove(carnet);
        }
    }
}
