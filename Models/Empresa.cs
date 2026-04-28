using System.ComponentModel.DataAnnotations;

namespace Nexora.Models
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria")]
        public string RazonSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUT es obligatorio")]
        public string Rut { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).{6,}$",
            ErrorMessage = "La contraseña debe tener al menos 6 caracteres, una mayúscula y un número")]
        public string Contraseña { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Telefono { get; set; } = string.Empty;
    }
}
