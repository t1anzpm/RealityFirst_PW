namespace ProyectoP3.Models
{
    public class ArtistasModels

    {
        public int IdArtista { get; set; }
        public string NombreArtista { get; set; }
        public int EdadArtista { get; set; }
        public string GeneroArtista { get; set; }
        public string FotoArtista { get; set; }
        public DateTime FecNacimiento { get; set; }
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FecNoticia { get; set; }
        public string Escritor { get; set; }
        public string Editor { get; set; }
        public string FotoNoticia { get; set; }
        public ArtistasModels()
        {

        }
    }
}
