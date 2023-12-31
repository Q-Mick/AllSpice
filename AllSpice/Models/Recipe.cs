namespace AllSpice.Models;

public class Recipe
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string Instructions { get; set; }
  public string Img { get; set; }
  public string Category { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
  
}
public class FavoriteRecipe : Recipe
{
    public int FavoriteId { get; set; }
}
 public class CollectionRecipe : Recipe // NOTE this is a view model
  {
    public int CollectionId { get; set; }
  }
