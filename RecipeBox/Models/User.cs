using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class User
    {
        public User()
        {
            this.Recipes = new HashSet<UserRecipe>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRecipe> Recipes { get; set; }
    }
}