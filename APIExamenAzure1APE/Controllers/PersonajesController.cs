using APIExamenAzure1APE.Models;
using APIExamenAzure1APE.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamenAzure1APE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;

        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajesSerie()
        {
            List<Personaje> personajes = this.repo.getPersonajes();
            return personajes;
        }

        [HttpGet("{idserie}")]
        public ActionResult<List<Personaje>> GetPersonajesSerie(int idserie)
        {
            List<Personaje> personajes = this.repo.GetPersonajesSerie(idserie);
            return personajes;
        }
        [HttpPost]
        public ActionResult InsertPersonaje(Personaje personaje)
        {
            this.repo.InsertPersonaje(personaje);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdatePersonaje(Personaje personaje)
        {
            this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }
        [HttpDelete("{idPersonaje}")]
        public void DeletePersonaje(int idPersonaje)
        {
            this.repo.DeletePersonaje(idPersonaje);
        }
    }
}
