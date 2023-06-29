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
  [HttpGet]
  public ActionResult<List<Recipe>> GetAllRecipes()
  {
    try
    {
      List<Recipe> Recipes = _recipesService.GetAllRecipes();
      return Ok(Recipes);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("{recipeId}")]
  public ActionResult<Recipe> GetById(int recipeId)
  {
    try
    {
      Recipe recipe = _recipesService.GetById(recipeId);
      return recipe;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpPut("{recipeId}")]
  [Authorize]
  public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId, [FromBody] Recipe recipeData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      recipeData.CreatorId = userInfo.Id;
      Recipe recipe = _recipesService.UpdateRecipe(recipeId ,recipeData);
      return new ActionResult<Recipe>(Ok(recipe));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpDelete("{recipeId}")]
  public ActionResult<string> DeleteRecipe(int recipeId)
  {
        try
    {
      string message = _recipesService.DeleteRecipe(recipeId);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}


