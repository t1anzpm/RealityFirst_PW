using ProyectoP3.Models;

namespace ProyectoP3.Servicio
{
    public class EventoServicio
    {
        private string Connection;

        public EventoServicio(string ConectionString)
        {
            this.Connection = ConectionString;
        }

        public EventosModels Get(int id)
        {
            EventosModels evento = new EventosModels();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT ev.IdEvento, ev.NomEvento, ev.LugarEvento, ev.FecEvento,ev.ImgEvento, ar.NomArtista, ar.GeneroMusical, ar.IdArtista FROM eventos AS ev JOIN Artista AS ar ON(ev.IdArtista = ar.IdArtista) where ev.IdArtista = {0};", id);
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            evento = new EventosModels()
                            {
                                IdEvento = reader.GetInt32(0),
                                NomEvento = reader.GetString(1),
                                LugarEvento = reader.GetString(2),
                                FecEvento = reader.GetString(3),
                                ImgEvento = reader.GetString(4),
                                NomArtista = reader.GetString(5),
                                GeneroMusical = reader.GetString(6),
                                IdArtista = reader.GetInt32(7)
                            };
                        }
                    }
                }
                server.Close();
            }
            return evento;
        }

        public IList<EventosModels> GetAll(int id)
        {
            IList<EventosModels> lista = new List<EventosModels>();

            using (SqlConnection server = new SqlConnection(this.Connection))
            {
                server.Open();

                string query = string.Format("SELECT ev.IdEvento, ev.NomEvento, ev.LugarEvento, ev.FecEvento,ev.ImgEvento, ar.NomArtista, ar.GeneroMusical, ar.IdArtista FROM eventos AS ev JOIN Artista AS ar ON(ev.IdArtista = ar.IdArtista) where ev.IdArtista = {0};", id);
                using (SqlCommand cmd = new SqlCommand(query, server))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new EventosModels()
                            {
                                IdEvento = reader.GetInt32(0),
                                NomEvento = reader.GetString(1),
                                LugarEvento = reader.GetString(2),
                                FecEvento = reader.GetString(3),
                                ImgEvento = reader.GetString(4),
                                NomArtista = reader.GetString(5),
                                GeneroMusical = reader.GetString(6),
                                IdArtista = reader.GetInt32(7)
                            });
                        }
                    }
                }
                server.Close();
            }
            return lista;
        }

    }


}
