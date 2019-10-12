using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecetasMockup.Models
{
    //TODO: HACER CABECERA DETALLE DE TRANSACCIONES
    [Table("VentaRecetas")]
    public class RecipeTransaction
    {
        [Key]
        public int Id { get; set; }

        //Columns related to Recipe components
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public float Qty { get; set; }

        //Columns related to audit transaction
        public DateTime DateAdded { get; set; }
        public string UserAdded { get; set; }
        public int Machine { get; set; }
    }
}