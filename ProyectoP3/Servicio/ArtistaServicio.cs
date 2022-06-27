using ProyectoP3.Models;
using ProyectoP3.Servicio.ServicioEstructura;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ProyectoP3.Servicio
{
    public class ArtistaServicio : IServicio<ArtistasModels>
    {
        private string Connection;

        public ArtistaServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public ArtistasModels Get(int id)
        {
            ArtistasModels artista = new ArtistasModels();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT ar.IdArtista, ar.NombreArtista, ar.EdadArtista, ar.GeneroArtista, ar.FotoArtista, ar.FecNacimiento, nt.IdNoticia, nt.Titulo, nt.Contenido, nt.FecNoticia, nt.Escritor, nt.Editor, nt.FotoNoticia from Artista AS ar JOIN noticia_artista AS nt ON(ar.IdArtista = nt.IdArtista) where ar.IdArtista = {0};", id);
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            artista = new ArtistasModels()
                            {
                                IdArtista = reader.GetInt32(0),
                                NombreArtista = reader.GetString(1),
                                EdadArtista = reader.GetInt32(2),
                                GeneroArtista = reader.GetString(3),
                                FotoArtista = reader.GetString(4),
                                FecNacimiento = reader.GetString(5),
                                IdNoticia = reader.GetInt32(6),
                                Titulo = reader.GetString(7),
                                Contenido = reader.GetString(8),
                                FecNoticia = reader.GetString(9),
                                Escritor = reader.GetString(10),
                                Editor = reader.GetString(11),
                                FotoNoticia = reader.GetString(12)

                            };
                        }
                    }
                }
                server.Close();
            }
            return artista;
        }

        public IList<ArtistasModels> GetAll()
        {
            IList<ArtistasModels> lista = new List<ArtistasModels>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT ar.IdArtista, ar.NombreArtista, ar.EdadArtista, ar.GeneroArtista, ar.FotoArtista, ar.FecNacimiento, nt.IdNoticia, nt.Titulo, nt.Contenido, nt.FecNoticia, nt.Escritor, nt.Editor, nt.FotoNoticia from Artista AS ar JOIN noticia_artista AS nt ON(ar.IdArtista = nt.IdArtista);");
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ArtistasModels()
                            {
                                IdArtista = reader.GetInt32(0),
                                NombreArtista = reader.GetString(1),
                                EdadArtista = reader.GetInt32(2),
                                GeneroArtista = reader.GetString(3),
                                FotoArtista = reader.GetString(4),
                                FecNacimiento = reader.GetString(5),
                                IdNoticia = reader.GetInt32(6),
                                Titulo = reader.GetString(7),
                                Contenido = reader.GetString(8),
                                FecNoticia = reader.GetString(9),
                                Escritor = reader.GetString(10),
                                Editor = reader.GetString(11),
                                FotoNoticia = reader.GetString(12)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }

        public void Create(ArtistasModels obj)
        {

        }

        public void Update(ArtistasModels obj)
        {

        }

        public void Delete(int id)
        {

        }

        public IList<ArtistasModels> FiltrarArtista(int id)
        {
            IList<ArtistasModels> lista = this.GetAll();
            return lista.Where(x => x.IdArtista == id).ToList();
        }

    }


}
