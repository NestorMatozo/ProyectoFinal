using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_ParteAdmin.Models
{
    public class Tikets
    {
        [Key]
        public int id_ticket { get; set; }
        public string? nombre_aplicativo { get; set; }
        public string? descripcion { get; set; }
        public string? archivos { get; set; }
        public string? prioridad { get; set; }
        public int id_cliente { get; set; }
        public string? comentario { get; set; }
    }
}
