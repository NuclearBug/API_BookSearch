using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookSearchAPI.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Class { get; set; }
        public string Sinopse { get; set; }
        public int NumCap { get; set; }
        public int NumPag { get; set; }
    }
}
