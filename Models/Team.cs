using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_gamer.Models
{
    public class Team
    {
        [Key] //DATA ANNOTATION - IDEQUIPE
        public int Id {get; set;}

        [Required]
        public string? Name {get; set;}
        public string? Image {get; set;}

        //REFERENCIA QUE A CLASSE TEAM TEM ACESSO A COLECTION PLAYER
        public ICollection<Player>? Player {get; set;}
    }
}