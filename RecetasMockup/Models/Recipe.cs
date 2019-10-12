using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecetasMockup.Models
{
    [Table("Receta")]
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Ingredient> Ingredients { get; set; }
    }
}