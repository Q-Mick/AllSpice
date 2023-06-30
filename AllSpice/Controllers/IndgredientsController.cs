namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;
  private readonly RecipesService _recipesService;
  private readonly Auth0Provider _auth0;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0, RecipesService recipesService)
  {
    _ingredientsService = ingredientsService;
    _auth0 = auth0;
    _recipesService = recipesService;
  }
    [HttpPost]
     public ActionResult<Ingredient> CreateIngredient([FromBody] Ingredient ingredientData)
  {
    try
    {
      Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData);
      return Ok(ingredient);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
      [HttpDelete("{ingredientId}")]
    public ActionResult<string> DeleteIngredient(int ingredientId)
    {
        try
        {
          
            _ingredientsService.DeleteIngredient(ingredientId);
            return Ok("Ingredient was successfully deleted!");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


  
}

