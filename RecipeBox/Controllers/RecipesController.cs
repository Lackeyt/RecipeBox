using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

//new using directives
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{
  [Authorize] //new line
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager; //new line

    //updated constructor
    public RecipesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    //updated Index method
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var AccountRecipes = _db.Recipes.Where(entry => entry.Account.Id == currentUser.Id);
      return View(AccountRecipes);
    }

    public ActionResult Create()
    {
      ViewBag.UserId = new SelectList(_db.Users, "UserId", "Name");
      return View();
    }

    //updated Create post method
    [HttpPost]
    public async Task<ActionResult> Create(Recipe recipe, int AccountId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      recipe.Account = currentUser;
      _db.Recipes.Add(recipe);
      if (AccountId != 0)
      {
        _db.AccountRecipe.Add(new AccountRecipe() { AccountId = AccountId, RecipeId = recipe.RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisRecipe = _db.Recipes
          .Include(recipe => recipe.Accounts)
          .ThenInclude(join => join.Account)
          .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    public ActionResult Edit(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      ViewBag.UserId = new SelectList(_db.Users, "UserId", "Name");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe, int AccountId)
    {
      if (AccountId != 0)
      {
        _db.AccountRecipe.Add(new AccountRecipe() { AccountId = AccountId, RecipeId = recipe.RecipeId });
      }
      _db.Entry(recipe).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddUser(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      ViewBag.UserId = new SelectList(_db.Users, "UserId", "Name");
      return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddUser(Recipe recipe, int AccountId)
    {
      if (AccountId != 0)
      {
        _db.AccountRecipe.Add(new AccountRecipe() { AccountId = AccountId, RecipeId = recipe.RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
      _db.Recipes.Remove(thisRecipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteUser(int joinId)
    {
      var joinEntry = _db.AccountRecipe.FirstOrDefault(entry => entry.AccountRecipeId == joinId);
      _db.AccountRecipe.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}