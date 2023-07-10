import { AppState } from '../AppState'
import { Ingredient } from '../models/Ingredient.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'


class IngredientService {


  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    AppState.ingredients = res.data.map(i => new Ingredient(i))
    logger.log('[RECIPE INGREDIENTS]', AppState.ingredients)
  }

  async createIngredient(newIngredient) {
    newIngredient.recipeId = AppState.activeRecipe.id
    const res = await api.post('api/ingredients', newIngredient)
    AppState.ingredients.push(new Ingredient(res.data))
  }

  async deleteIngredient(ingredientId) {
    await api.delete(`api/ingredients/${ingredientId}`)
    const ingredientToDelete = AppState.ingredients.findIndex(i => i.id == ingredientId)
    AppState.ingredients.splice(ingredientToDelete, 1)
  }

  async editIngredient(ingredientData) {
    const res = await api.put(`api/ingredients/${ingredientData.id}`, ingredientData)
    AppState.ingredients = res.data.map(i => new Ingredient(i))
    logger.log('[EDITED INGREDIENT]', res.data)
  }

}

export const ingredientsService = new IngredientsService()