namespace AllSpice.Repositories;

public class IngredientsRepository
{
  private readonly IDbConnection _db;
  public IngredientsRepository(IDbConnection db)
  {
    _db = db;
  }
  internal Ingredient CreateIngredient(Ingredient ingredientData)
  {
    string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@Name, @Quantity, @RecipeId);

            SELECT
            ing.*,
            rec.*
            FROM ingredients ing
            JOIN recipes rec ON ing.recipeId = rec.Id
            ";
    Ingredient newIngredient = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
    {
      ingredient.RecipeId = recipe.Id;
      return ingredient;
    }, ingredientData).FirstOrDefault();

    return newIngredient;
  }

  internal Ingredient GetById(int ingredientId)
  {
    throw new NotImplementedException();
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    throw new NotImplementedException();
  }
}



