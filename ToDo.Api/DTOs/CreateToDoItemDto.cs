using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.DTOs
{
    public class CreateToDoItemDto
    {
        [Required(ErrorMessage = "Se requiere un valor para el campo {0}")]
        [StringLength(10, ErrorMessage ="El campo {0} debe tener {1} o menos caracteres")]
        public string Name { get; set; } = string.Empty;

        // Esto se debe borrar
        [Range(18, 65, ErrorMessage = "El campo {0} debe estar entre {1} y {2} años")]
        public int Edad { get; set; }
    }
}
