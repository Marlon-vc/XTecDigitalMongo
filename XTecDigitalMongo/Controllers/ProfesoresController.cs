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
    public class ProfesoresController : ControllerBase
    {
        private readonly ProfesorService _service;
        public ProfesoresController(ProfesorService service)
        {
            _service = service;
        }

        // GET: api/<ProfesoresController>
        [HttpGet]
        public IEnumerable<Profesor> Get()
        {
            return _service.Get();
        }

        // GET api/<ProfesoresController>/5
        [HttpGet("{cedula}")]
        public Profesor Get(string cedula)
        {
            return _service.Get(cedula);
        }

        // POST api/<ProfesoresController>
        [HttpPost]
        public void Post(Profesor profesor)
        {
            _service.Create(profesor);
        }

        // PUT api/<ProfesoresController>/5
        [HttpPut("{cedula}")]
        public void Put(string cedula, Profesor profesor)
        {
            _service.Update(cedula, profesor);
        }

        // DELETE api/<ProfesoresController>/5
        [HttpDelete("{cedula}")]
        public void Delete(string cedula)
        {
            _service.Remove(cedula);
        }
    }
}
