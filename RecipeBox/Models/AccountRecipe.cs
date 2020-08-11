namespace RecipeBox.Models
{
  public class AccountRecipe
    {       
        public int AccountRecipeId { get; set; }
        public int RecipeId { get; set; }
        public int AccountId { get; set; }
        public Recipe Recipe { get; set; }
        public Account Account { get; set; }
    }
}