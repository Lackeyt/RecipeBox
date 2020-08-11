using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecipeBox.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Recipe> Recipes {get;set;}
    public DbSet<Account> Accounts {get;set;}
    public DbSet<AccountRecipe> AccountRecipe {get;set;}
    public RecipeBoxContext(DbContextOptions options) : base(options) {}
  }
}