import { api } from "./AxiosService";
import { AppState } from "../AppState";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger";
import Pop from "../utils/Pop.js";
class RecipeService {
  async getRecipes() {
    const res = await api.get("/api/recipes");
    AppState.recipes = res.data.map((r) => new Recipe(r));
    // logger.log("[RECIPES]", res.data)
  }
  async getRecipeById(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`);

    return new Recipe(res.data)
  }

  async setActiveRecipe(recipeId) {
    AppState.activeRecipe = await this.getRecipeById(recipeId)
    logger.log(`[SETTING ACTIVE RECIPE] - ID ${recipeId} - Name:${AppState.activeRecipe.title}`)
  }
  async createRecipe(recipeData) {
    const res = await api.post('api/recipes', recipeData)
    const newRecipe = new Recipe(res.data)
    logger.log(newRecipe)
    AppState.recipes.unshift(newRecipe)
    // this.getRecipes()
    Pop.success(`Recipe created!`)
    return newRecipe
  }

  async editRecipe(recipeId, recipeData){
    const res = await api.put(`api/recipes/${recipeId}`, recipeData)
    return res.data
  }
}

export const recipeService = new RecipeService();
