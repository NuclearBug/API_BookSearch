using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSearchAPI.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        [Key]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
