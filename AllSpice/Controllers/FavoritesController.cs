namespace AllSpice.Controllers;


[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
  private readonly FavoritesService _favoritesService;
  private readonly Auth0Provider _auth0;

  public FavoritesController(FavoritesService favoritesService, Auth0Provider auth0)
  {
    _favoritesService = favoritesService;
    _auth0 = auth0;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      favoriteData.AccountId = userInfo.Id;
      Favorite newFavorite = _favoritesService.CreateFavorite(favoriteData);
      return Ok(newFavorite);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{favoriteId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteFavorite(int favoriteId)
  {
    try
    {
      Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
      _favoritesService.DeleteFavorite(favoriteId, userInfo.Id);
      return Ok("Favorite succesfully removed.");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}

