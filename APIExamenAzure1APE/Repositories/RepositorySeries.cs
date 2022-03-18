using APIExamenAzure1APE.Data;
using APIExamenAzure1APE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIExamenAzure1APE.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public Serie FindSerie(int idSerie)
        {
            return this.context.Series.Where(x => x.IdSerie == idSerie).FirstOrDefault();
        }

        public Personaje FindPersonaje(int idPersonaje)
        {
            return this.context.Personajes.Where(x => x.IdPersonaje == idPersonaje).FirstOrDefault();
        }

        public List<Personaje> getPersonajes()
        {
            return this.context.Personajes.ToList();
        }

        public List<Serie> GetAllSeries()
        {
            return this.context.Series.ToList();
        }

        public List<Personaje> GetPersonajesSerie(int idSerie) 
        {
            return this.context.Personajes.Where(x => x.IdSerie == idSerie).ToList();
        }

        public void InsertPersonaje(Personaje personaje)
        {
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
        }

        public void InsertSerie(Serie serie)
        {
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
        public void InsertPersonaje(int idSerie, string NombreSerie, string Imagen,
                                    double Puntuacion, int Año)
        {
            Serie serie = new Serie
            {
                IdSerie = idSerie,
                NombreSerie = NombreSerie,
                Imagen = Imagen,
                Puntuacion = Puntuacion,
                Año = Año,
            };
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
        public void UpdateSerie(int idSerie, string NombreSerie, string Imagen,
                                    double Puntuacion, int Año)
        {
            Serie serie = this.FindSerie(idSerie);
            serie.NombreSerie = NombreSerie;
            serie.Imagen = Imagen;
            serie.Puntuacion = Puntuacion;
            serie.Año = Año;
            this.context.SaveChanges();
        }

        internal void UpdatePersonaje(int IdPersonaje, string NombrePersonaje, string Imagen, int IdSerie)
        {
            Personaje personaje = this.FindPersonaje(IdPersonaje);
            personaje.NombrePersonaje = NombrePersonaje;
            personaje.Imagen = Imagen;
            personaje.IdSerie = IdSerie;
            this.context.SaveChanges();
        }

        public void DeleteSerie(int idSerie)
        {
            Serie serie = this.FindSerie(idSerie);
            this.context.Series.Remove(serie);
            this.context.SaveChanges();
        }
        public void DeletePersonaje(int idPersonaje)
        {
            Personaje personaje = this.FindPersonaje(idPersonaje);
            this.context.Personajes.Remove(personaje);
            this.context.SaveChanges();
        }

    }
}
