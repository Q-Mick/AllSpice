namespace AllSpice.Repositories;

public class FavoritesRepository
{
  private readonly IDbConnection _db;

  public FavoritesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Favorite CreateFavorite(Favorite favoriteData)
  {
    string sql = @"
    INSERT INTO favorites
    (accountId, recipeId)
    VALUES
    (@accountId, @recipeId);
    SELECT LAST_INSERT_ID();
    ";
    int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
    favoriteData.Id = lastInsertId;
    return favoriteData;
  }

  internal List<FavoriteRecipe> GetMyFavoriteRecipes(string accountId)
  {
    string sql = @"
    SELECT
    favs.*,
    recipe.*,
    act.*
    FROM favorites favs
    JOIN recipes recipe ON recipe.id = favs.recipeId
    JOIN accounts act ON act.id = recipe.creatorId
    WHERE favs.accountId = @accountId
    ";
    List<FavoriteRecipe> myFavorites = _db.Query<Favorite, FavoriteRecipe, Account, FavoriteRecipe>(sql,(favorite, recipe, account) =>
    {
        recipe.FavoriteId = favorite.Id;
        recipe.Creator = account;
        return recipe;
    }, new { accountId }).ToList();
    return myFavorites;
  }
      internal int DeleteFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId
        LIMIT 1
        ;";
        int rows = _db.Execute(sql, new { favoriteId });
        return rows;
    }
        internal Favorite GetById(int favoriteId)
    {
        string sql = @"
        SELECT
        favs.*
        FROM favorites favs
        WHERE favs.id = @favoriteId
        ;";
        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }
}
