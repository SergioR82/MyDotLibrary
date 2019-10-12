using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecetasMockup.Models
{
    [Table("Ingrediente")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public int? FeedstockId {get;set;}
        public virtual Feedstock Product { get; set; }

        public int Qty { get; set; }
    }
}