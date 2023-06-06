using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace projeto_gamer.Models
{

    [Keyless]
    public class Login
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}