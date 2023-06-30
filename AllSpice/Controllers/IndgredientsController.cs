namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
  private readonly IngredientsService _ingredientsService;
  private readonly Auth0Provider _auth0;

  public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0)
  {
    _ingredientsService = ingredientsService;
    _auth0 = auth0;
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



  
}

