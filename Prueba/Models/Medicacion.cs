using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Prueba.Models
{
    public class Medicacion
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nombre de la Medicación")]
        [NotNull]
        [MaxLength(40, ErrorMessage = "El nombre máximo de caracteres a ingresar es de 40")]
        public string Nombre { get; set; }

        [DisplayName("Descripción de la Medicación")]
        [NotNull]
        public string Descripcion { get; set; }

        [ForeignKey("HistorialMedicoId")]
        public int HistorialMedicoId { get; set; }
        public HistorialMedico HistorialMedico { get; set; }
    }
}
