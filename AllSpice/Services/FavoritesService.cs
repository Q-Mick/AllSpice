namespace AllSpice.Services;

public class FavoritesService
    {
            private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite newFavorite = _repo.CreateFavorite(favoriteData);
        return newFavorite;
    }
        internal List<FavoriteRecipe> GetMyFavoriteRecipes(string accountId)
    {
        List<FavoriteRecipe> myFavorites = _repo.GetMyFavoriteRecipes(accountId);
        return myFavorites;
    }
        internal void DeleteFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetById(favoriteId);
        if (favorite.AccountId != userId) new Exception("Unauthorized to remove this collaborator!");
        int rows = _repo.DeleteFavorite(favoriteId);
        if (rows > 1) new Exception("Something went wrong");
    }
        internal Favorite GetById(int favoriteId)
    {
        Favorite favorite = _repo.GetById(favoriteId);
        if (favorite == null) new Exception("Invalid id");
        return favorite;
    }
    }
