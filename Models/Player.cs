using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_gamer.Models
{
    public class Player
    {
        [Key] //data annotation chave primaria
        public int PlayerId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [ForeignKey("Team")] //data annotation chave estrangeira
        public int Id { get; set; }

        public Team? Team {get; set;}
    }
}