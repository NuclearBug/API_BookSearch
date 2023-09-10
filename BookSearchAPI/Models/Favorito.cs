using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSearchAPI.Models
{
    public class Favorito
    {
        [Key]
        public int Id_favorito { get; set; }
        public string Email { get; set; }
        public int Id_livro { get; set; }
    }
}
