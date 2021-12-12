using System.ComponentModel.DataAnnotations;

namespace WS_Mascotas.Models
{
    public class AuthModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
