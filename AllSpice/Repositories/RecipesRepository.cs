namespace AllSpice.Repositories;

public class RecipesRepository
{
  private readonly IDbConnection _db; // NOTE these are the dependancies

  public RecipesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Recipe CreateRecipe(Recipe recipeData)
  {
    string sql = @"
    INSERT INTO recipes
    (title, instructions, img, category, creatorId)
    VALUES
    (@title, @instructions, @img, @category, @creatorId);

    SELECT
        recipe.*,
        creator.*
    FROM recipes recipe
    JOIN accounts creator ON recipe.creatorId = creator.id
    WHERE recipe.id = LAST_INSERT_ID()
    ;";
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator; // NOTE this is where your creator is populated with the account data
      return recipe;
    }, recipeData).FirstOrDefault();
    return recipe;
  }

  internal List<Recipe> GetAllRecipes()
  {
    string sql = @"
    SELECT
    recipe.*,
    creator.*
    FROM recipes recipe
    JOIN accounts creator ON recipe.creatorId = creator.id;
    ";
    List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe;
    }).ToList();
    return recipes;
  }

  internal Recipe GetById(int recipeId)
  {
    string sql = @"
    SELECT
    recipe.*,
    creator.*
    FROM recipes recipe
    JOIN accounts creator ON recipe.creatorId = creator.id
    WHERE recipe.id = @recipeId;
    ";
    Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, creator) =>
    {
      recipe.Creator = creator;
      return recipe;
    }, new { recipeId }).FirstOrDefault();
    return recipe;
  }
  internal void UpdateRecipe(Recipe recipe)
  {
    string sql = @"
    UPDATE recipes SET
    title = @title,
    instructions = @instructions,
    img = @img,
    category = @category
    WHERE id = @id;
    ";
    _db.Execute(sql, recipe);
  }
    internal int DeleteRecipe(int recipeId)
  {
    string sql = "DELETE FROM recipe WHERE id = @id LIMIT 1;";
    int rows = _db.Execute(sql, new { recipeId });
    return rows;
  }
}
