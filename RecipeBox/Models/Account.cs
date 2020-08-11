using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Account
    {
        public Account()
        {
            this.Recipes = new HashSet<AccountRecipe>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AccountRecipe> Recipes { get; set; }
    }
}