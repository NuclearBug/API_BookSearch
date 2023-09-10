using Microsoft.EntityFrameworkCore;

namespace BookSearchAPI.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Class { get; set; }
        public string Sinopse { get; set; }
        public int NumCap { get; set; }
        public int NumPag { get; set; }
        public bool Favorito { get; set; }
    }
}
