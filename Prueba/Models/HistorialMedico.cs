using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba.Models
{
    public class HistorialMedico
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Condiciones Preexistentes")]
        public List<Condicion> CondicionesPreexistentes { get; set; }

        [DisplayName("Alergias")]
        public List<Alergia> Alergias { get; set; }

        [DisplayName("Medicaciones Actuales")]
        public List<Medicacion> MedicacionesActuales { get; set; }

        [DisplayName("Tratamientos Anteriores")]
        public List<Tratamiento> TratamientosAnteriores { get; set; }

        [ForeignKey("PacienteId")]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }

}
