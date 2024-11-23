using System.ComponentModel.DataAnnotations;

namespace GestionRecursosHumanos2.Models
{
    public class Departamentos
    {
        [Key]
        public int IdDepartamento { get; set; }
        [Required]
        public string NombreDepartamento { get; set; }
        public string UbicacionDepartamento { get; set; }
    }
}
