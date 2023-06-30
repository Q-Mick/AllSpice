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
    // TODO add delete this method
        internal void DeleteIngredient(int ingredientId)
    {        
        int rows = _repo.DeleteIngredient(ingredientId);
        if (rows > 1) new Exception("Deleted more than 1 row, something is wrong.");
    }
}


