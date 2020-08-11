using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Recipe> Recipes {get;set;}
    public DbSet<Category> Categories {get;set;}
    public DbSet<CategoryRecipe> CategoryRecipe {get;set;}
    public RecipeBoxContext(DbContextOptions options) : base(options) {}
  }
}