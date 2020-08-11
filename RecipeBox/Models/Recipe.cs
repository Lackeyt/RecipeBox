using System.Collections.Generic;

namespace RecipeBox.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Accounts = new HashSet<AccountRecipe>();
        }

        public int RecipeId { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser Account { get; set; } //new line

        public ICollection<AccountRecipe> Accounts { get;}
    }
}