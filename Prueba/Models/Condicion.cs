using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Models
{
    public class Condicion
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nombre de la Condición")]
        [NotNull]
        [MaxLength(40, ErrorMessage = "El nombre máximo de caracteres a ingresar es de 40")]
        public string Nombre { get; set; }
        [DisplayName("Descripción de la Condición")]
        [NotNull]
        public string Descripcion { get; set; }

        [ForeignKey("HistorialMedicoId")]
        public int HistorialMedicoId { get; set; }
        public HistorialMedico HistorialMedico { get; set; }
    }
}
