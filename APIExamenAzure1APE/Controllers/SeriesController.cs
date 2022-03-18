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
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;

        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Serie>> GetAllSeries()
        {
            List<Serie> series = this.repo.GetAllSeries();
            return series;
        }

        [HttpGet("{id}")]
        public ActionResult<Serie> GetSerie(int id)
        {
            Serie serie = this.repo.FindSerie(id);
            return serie;
        }

        [HttpPost]
        public ActionResult InsertSerie(Serie serie)
        {
            this.repo.InsertSerie(serie);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateSerie(Serie serie)
        {
            this.repo.UpdateSerie(serie.IdSerie,serie.NombreSerie,serie.Imagen,serie.Puntuacion,serie.Año);
            return Ok();
        }

        [HttpDelete("{idSerie}")]
        public void DeleteSerie(int idSerie)
        {
            this.repo.DeleteSerie(idSerie);
        }

    }
}
