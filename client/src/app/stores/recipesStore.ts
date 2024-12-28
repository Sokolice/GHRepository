import { makeAutoObservable, runInAction } from "mobx";
import { Recipe } from "../../models/Recipe";
import axios from "axios";
import { store } from "./store";
export default class RecipesStore {
  recipes = new Array<Recipe>();

  constructor() {
    makeAutoObservable(this);
  }

  get getRecipes() {
    return this.recipes;
  }

  loadRecipes = async (name: string) => {
    store.globalStore.loading = true;
    const url = import.meta.env.VITE_RECIPE_URL + `/${name}`;
    const response = await axios.get(url);
    console.log(response.data);
    runInAction(() => {
      this.recipes = response.data;

      store.globalStore.loading = false;
    });
  };
}
