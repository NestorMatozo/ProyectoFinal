using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class Asignaciones_act
    {
        [Key]
        public int id_asignacionesact { get; set; }
        public int id_asignaciones { get; set; }
        public string? actividad { get; set; }

        public string? detalle { get; set; }
        public string? estado { get; set; }
    }
}
