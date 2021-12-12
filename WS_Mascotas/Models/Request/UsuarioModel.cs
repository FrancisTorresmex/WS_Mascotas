using System.ComponentModel.DataAnnotations;

namespace WS_Mascotas.Models.Request
{
    public class UsuarioModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
