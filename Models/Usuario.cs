using System.ComponentModel.DataAnnotations;

namespace Nexora.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUT es obligatorio")]
        public string Rut { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número de teléfono es obligatorio")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{6,}$",
            ErrorMessage = "La contraseña debe tener al menos 6 caracteres, una mayúscula y un número")]
        public string Contraseña { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; } = string.Empty;
    }
}
