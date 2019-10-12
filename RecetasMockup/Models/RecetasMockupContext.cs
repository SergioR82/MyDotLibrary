using RecetasMockup.Models;
using System;
using System.Data.Entity;

namespace RecetasMockup
{
    public class RecetasMockupContext : DbContext
    {
        public RecetasMockupContext() : base("name=RecetasMockupContext") { }

        public virtual DbSet<RecipeTransaction> Transactions { get; set; }

    }
}