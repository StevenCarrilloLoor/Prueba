using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Prueba.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nombre del Paciente")]
        [NotNull]
        [MaxLength(40, ErrorMessage = "El nombre máximo de caracteres a ingresar es de 40")]
        public string Nombre { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Género")]
        [NotNull]
        public string Genero { get; set; }

        [DisplayName("Dirección")]
        [NotNull]
        public string Direccion { get; set; }

        [DisplayName("Datos de Contacto")]
        [NotNull]
        public string DatosContacto { get; set; }
    }

}
