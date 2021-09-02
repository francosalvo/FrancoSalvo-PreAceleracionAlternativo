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
    public class IconosController : ControllerBase 
    {
        private readonly GeoIconsContext _context;
        private object GeograpihcIcon;

        public IconosController (GeoIconsContext context) 
        {
            _context = context;
        }

        //TODO: LISTAR ICONOS
        [HttpGet]
        [Route(template: "api/[controller]/listado")]
        public IActionResult Get()
        {
            return Ok(_context.GeograpihcIcons.ToList());
        }
        //TODO: crear

        [HttpPost]
        [Route(template: "api/[controller]/Create")]
        public IActionResult Post(GeograpihcIcon geoicon)
        {
            _context.GeograpihcIcons.Add(geoicon);
            _context.SaveChanges();
            return Ok(_context.GeograpihcIcons.ToList());
        }

        //TODO: modificar
        [HttpPut]
        [Route(template: "api/[controller]/Update")]
        public IActionResult Put(GeograpihcIcon geoicon)
        {
            if (_context.GeograpihcIcons.FirstOrDefault(g => g.Id == geoicon.Id) == null) return BadRequest("EL Icono geografico enviado no existe");
            var internalIcon = _context.GeograpihcIcons.Find(geoicon.Id);

            internalIcon.Denomination = geoicon.Denomination;
            internalIcon.Image = geoicon.Image;
            internalIcon.GetDate = geoicon.GetDate;

            return Ok(_context.GeograpihcIcons.ToList());
        }
        //TODO: borrar
        [HttpDelete]
        [Route("{id}/Delete")]
        public IActionResult Delete(int id)
        {
            if (_context.GeograpihcIcons.FirstOrDefault(g => g.Id == id) == null) return BadRequest("EL Icono geografico enviado no existe");

            var internalIcon = _context.GeograpihcIcons.Find(id);
            _context.GeograpihcIcons.Remove(internalIcon);
            _context.SaveChanges();
            return Ok();
        }








    }
}
