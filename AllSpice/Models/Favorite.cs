namespace AllSpice.Models
{
  public class Favorite
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public int RecipeId { get; set; }
    }

    public class FavoriteAccount : Account
{
    public int FavoriteId { get; set; }
}
}