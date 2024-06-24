using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Prueba.Models
{
    public class Tratamiento
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Identificador del Tratamiento")]
        [NotNull]
        public string Identificador { get; set; }

        [DisplayName("Descripción del Tratamiento")]
        [NotNull]
        public string Descripcion { get; set; }

        [DisplayName("Notas del Tratamiento")]
        public string Notas { get; set; }

        [DisplayName("Instrucciones de Dosificación")]
        public string InstruccionesDosificacion { get; set; }

        [DisplayName("Frecuencia de Administración")]
        public string FrecuenciaAdministracion { get; set; }

        [DisplayName("Efectos Secundarios")]
        public string EfectosSecundarios { get; set; }

        [ForeignKey("HistorialMedicoId")]
        public int HistorialMedicoId { get; set; }
        public HistorialMedico HistorialMedico { get; set; }
    }
}
