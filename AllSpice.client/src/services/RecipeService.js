import { api } from "./AxiosService";
import { AppState } from "../AppState";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger";
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
}

export const recipeService = new RecipeService();
