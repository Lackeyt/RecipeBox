using System.Collections.Generic;

namespace RecipeBox.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Users = new HashSet<UserRecipe>();
        }

        public int RecipeId { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser User { get; set; } //new line

        public ICollection<UserRecipe> Users { get;}
    }
}