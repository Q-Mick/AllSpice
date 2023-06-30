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
            (@name, @quantity, @recipeId);

            SELECT
            ing.*,
            rec.*
            FROM ingredients ing
            JOIN recipes rec ON ing.recipeId = rec.Id
            WHERE ing.id = LAST_INSERT_ID();
            ";
    Ingredient newIngredient = _db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
    {
      ingredient.RecipeId = recipe.Id;
      return ingredient;
    }, ingredientData).FirstOrDefault();

    return newIngredient;
  }

  internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
  {
    string sql = @"
  SELECT
  * 
  FROM ingredients
  WHERE recipeId = @recipeId
  ;";
    List<Ingredient> recipeIngredients = _db.Query<Ingredient>(sql, new {recipeId}).ToList();
    // let ingredients = await dbContext.Ingredients.find({recipeId})
    return new List<Ingredient>(recipeIngredients);
  }
      internal int DeleteIngredient(int ingredientId)
    {

        string sql = @"
        DELETE FROM ingredients 
        WHERE id = @ingredientId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { ingredientId });
        return rows;
    }
}



