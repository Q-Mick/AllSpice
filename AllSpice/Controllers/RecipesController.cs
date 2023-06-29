namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth;
  public RecipesController(RecipesService recipeService, Auth0Provider auth)
  {
    _recipesService = recipeService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe newRecipe = _recipesService.CreateRecipe(recipeData);
      return new ActionResult<Recipe>(Ok(newRecipe));
    }
    catch (Exception e)
    {
      return new ActionResult<Recipe>(BadRequest(e.Message));
    }
  }
}