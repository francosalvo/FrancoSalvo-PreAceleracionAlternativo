using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Challenge.PreAcel.Contexts;
using Challenge.PreAcel.Entities;

namespace Challenge.PreAcel.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class ContinentController : ControllerBase
    {
        private readonly GeoIconsContext _context;
        private object continet;

        public ContinentController(GeoIconsContext context)
        {
            _context = context;

        }

        //TODO: leer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Continents.ToList());
        }

        //TODO: leer
        [HttpGet("{id}")]
        public ActionResult<Continent> GetContinentById(int id)
        {
            //return Ok(_context.Continents.Where(c => c.Id == id));
            return Ok(_context.Continents.Find(id));
        }

        //TODO: crear

        [HttpPost]
        public IActionResult Post(Continent continet)
        {
            _context.Continents.Add(continet);
            _context.SaveChanges();
            return Ok(_context.Continents.ToList());
        }

        //TODO: modificar
        [HttpPut]
        public IActionResult Put(Continent continet)
        {
            if (_context.Continents.FirstOrDefault(c => c.Id == continet.Id) == null) return BadRequest("EL contiente enviado no existe");
            var internalContinent = _context.Continents.Find(continet.Id);

            internalContinent.Denomination = continet.Denomination;
            internalContinent.Image = continet.Image;

            return Ok(_context.Continents.ToList());
        }
        //TODO: borrar
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_context.Continents.FirstOrDefault(c => c.Id == id) == null) return BadRequest("EL contiente enviado no existe");

            var internalContinent = _context.Continents.Find(id);
            _context.Continents.Remove(internalContinent);
            _context.SaveChanges();
            return Ok();
        }




    }
}
