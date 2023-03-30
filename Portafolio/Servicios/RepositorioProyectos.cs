using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() {
                new Proyecto {
                    Titulo = "Amazon",
                    Descripcion = "E-Commerce realizado en ASP.NET CORE",
                    link = "https://amazon.com",
                    ImagenURL = "/imagenes/amazon.png"
                },
                new Proyecto {
                    Titulo = "New York Times",
                    Descripcion = "Paginas de noticias en React",
                    link = "https://nytimes.com",
                    ImagenURL = "/imagenes/nyt.png"
                },
                new Proyecto {
                    Titulo = "Reddit",
                    Descripcion = "Red social para compartir en comunidades",
                    link = "https://reddit.com",
                    ImagenURL = "/imagenes/reddit.png"
                },
                new Proyecto {
                    Titulo = "Steam",
                    Descripcion = "Tienda en linea para comprar videojuegos",
                    link = "https://store.steampowerd.com",
                    ImagenURL = "/imagenes/steam.png"
                },
            };
        }
    }
}
