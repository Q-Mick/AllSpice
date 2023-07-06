import { api } from './AxiosService'
import { AppState } from '../AppState'
import { Recipe } from '../models/Recipe.js'
import { logger } from '../utils/Logger'
class RecipeService {
  async getRecipes() {
      const res = await api.get('/api/recipes')
      AppState.recipes = res.data.map(r => new Recipe(r))
      // logger.log("[RECIPES]", res.data)
  
    }
  }

export const recipeService = new RecipeService()
