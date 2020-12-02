using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using XTecDigitalMongo.Helpers;
using XTecDigitalMongo.Models;
using XTecDigitalMongo.Services;

namespace XTecDigitalMongo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController: ControllerBase
    {
        
        private readonly AdminService _service;

        public AdminController(AdminService service)
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
        [HttpGet("{user}")]
        public IActionResult Get(string user)
        {
            var admin = _service.Get(user);

            if (admin == null)
                return NotFound();
            
            return Ok(admin);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public IActionResult Post(Admin admin)
        {
            if (AdminExists(admin.User))
                return Conflict();
            
            admin.Pass = Encryption.Md5(admin.Pass);
            _service.Create(admin);

            return CreatedAtRoute("Default", new { user = admin.User}, admin);
        }

        [HttpPost("batch")]
        public IActionResult PostList(List<Admin> admins)
        {
            foreach (var admin in admins)
            {
                admin.Pass = Encryption.Md5(admin.Pass);
            }
            _service.Create(admins);
            return Ok(admins);
        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{user}")]
        public IActionResult Put(string user, Admin admin)
        {
            if (user != admin.User)
                return BadRequest();

            if (!AdminExists(user))
                return NotFound();
            
            _service.Update(user, admin);
            return Ok(admin);
        }

        // DELETE api/<EstudiantesController>/password/5
        [HttpPut("password/{user}")]
        public IActionResult PutPassword(string user, Admin admin)
        {
            if (admin.User != user)
                return BadRequest();

            if (!AdminExists(user))
                return NotFound();

            admin.Pass = Encryption.Md5(admin.Pass);
            _service.Update(user, admin);

            return Ok(admin);
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{user}")]
        public IActionResult Delete(string user)
        {
            if (!AdminExists(user))
                return NotFound();

            _service.Remove(user);
            return Ok();
        }

        public bool AdminExists(string user)
        {
            return _service.Get(user) != null;
        }
    }
}