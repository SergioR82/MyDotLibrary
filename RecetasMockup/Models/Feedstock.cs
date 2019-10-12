using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RecetasMockup.Models
{
    [Table("MateriaPrima")]
    public class Feedstock
    {
        [Key]
        public int Id { get; set; }
        public string Descr { get; set; }
        public float Units { get; set; }
    }
}