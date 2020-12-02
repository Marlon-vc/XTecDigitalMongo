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
    public class ProfesoresController : ControllerBase
    {
        private readonly ProfesorService _service;
        public ProfesoresController(ProfesorService service)
        {
            _service = service;
        }

        // GET: api/<ProfesoresController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        // GET api/<ProfesoresController>/5
        [HttpGet("{cedula}")]
        public IActionResult Get(string cedula)
        {
            var prof = _service.Get(cedula);

            if (prof == null)
                return NotFound();
                
            return Ok(prof);
        }

        // POST api/<ProfesoresController>
        [HttpPost]
        public IActionResult Post(Profesor profesor)
        {
            if (ProfesorExists(profesor.Cedula))
                return Conflict();

            profesor.Pass = Encryption.Md5(profesor.Pass);
            _service.Create(profesor);

            return CreatedAtRoute("Default", new { cedula = profesor.Cedula }, profesor);
        }

        // PUT api/<ProfesoresController>/5
        [HttpPut("{cedula}")]
        public IActionResult Put(string cedula, Profesor profesor)
        {
            if (cedula != profesor.Cedula)
                return BadRequest();
            
            if (!ProfesorExists(cedula))
                return NotFound();

            _service.Update(cedula, profesor);

            return Ok(profesor);
        }

        // DELETE api/<ProfesoresController>/5
        [HttpDelete("{cedula}")]
        public IActionResult Delete(string cedula)
        {
            if (!ProfesorExists(cedula))
                return NotFound();

            _service.Remove(cedula);

            return Ok();
        }

        public bool ProfesorExists(string cedula)
        {
            return _service.Get(cedula) != null;
        }
    }
}
