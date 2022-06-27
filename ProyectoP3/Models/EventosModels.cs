namespace ProyectoP3.Models
{
    public class EventosModels
    {
        public int IdEvento { get; set; }
        public string NomEvento { get; set; }
        public string LugarEvento { get; set; }
        public string FecEvento { get; set; }
        public string ImgEvento { get; set; }
        public string NomArtista { get; set; }
        public string GeneroMusical { get; set; }
        public int IdArtista { get; set; }
        public EventosModels()
        { 
        
        }
    }
}
