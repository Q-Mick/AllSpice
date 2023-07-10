namespace AllSpice.Services;

public class RecipesService
{
  private readonly RecipesRepository _repo;

  public RecipesService(RecipesRepository repo)
  {
    _repo = repo;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    Recipe recipe = _repo.CreateRecipe(recipeData);
    return recipe;
  }
  internal List<Recipe> GetAllRecipes()
  {
    List<Recipe> recipes = _repo.GetAllRecipes();
    return recipes;
  }
  internal Recipe GetById(int recipeId)
  {
    Recipe recipe = _repo.GetById(recipeId);
    if (recipe == null) throw new Exception($"no recipe at id:{recipeId}.");
    return recipe;
  }

  internal Recipe UpdateRecipe(int recipeId, Recipe recipeData)
  {
    Recipe oldRecipe = GetById(recipeId);
    if (oldRecipe.CreatorId != recipeData.CreatorId) throw new Exception("Shoo fly!");

    oldRecipe.Title = recipeData.Title != null ? recipeData.Title : oldRecipe.Title;
    oldRecipe.Category = recipeData.Category != null ? recipeData.Category : oldRecipe.Category;
    oldRecipe.Img = recipeData.Img != null ? recipeData.Img : oldRecipe.Img;
    oldRecipe.Instructions = recipeData.Instructions != null ? recipeData.Instructions : oldRecipe.Instructions;
    oldRecipe.Description = recipeData.Description != null ? recipeData.Description : oldRecipe.Description;
  
    _repo.UpdateRecipe(oldRecipe);
    return oldRecipe;
  }
    internal string DeleteRecipe(int recipeId)
  {
    Recipe recipe = GetById(recipeId);
    // TODO add account checks

    int rows = _repo.DeleteRecipe(recipeId);
    if (rows > 1) throw new Exception("system will sef destruct in T-minus 5....4...3..2.RUUUNNNNN");

    return $"Deleted{recipe.Title}.";
  }
}
