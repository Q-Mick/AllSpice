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
}
