namespace AllSpice.Services;

public class IngredientsService
{
  private readonly IngredientsRepository _repo;
//   private readonly RecipesRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient newIngredient = _repo.CreateIngredient(ingredientData);
        return(newIngredient);
        // NOTE one line version is return _repo.CreateIngredient(ingredientData);
    }
    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
    // internal void DeleteIngredient(int recipeId, int ingredientId)
    // {
    //     Ingredient ingredient = RecipesService.GetById(ingredientId);
    //     if (picture.CreatorId != userId) new Exception("Nacho picture");
    // }
}


