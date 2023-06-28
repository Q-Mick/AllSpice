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
}