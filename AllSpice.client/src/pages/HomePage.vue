<template>
  <section id="hero" class="shadow-xl">
    <div class="relative h-[20rem] md:h-[25rem] w-full bg-cover bg-center"
      style="background-image: url('https://images.unsplash.com/photo-1564149504298-00c351fd7f16?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80')">
      <!-- NOTE CONTAINER TO POSITION ITEMS -->
      <div class="flex-col absolute inset-0 bg-black bg-opacity-50 flex items-center justify-center">
        <!-- SECTION SEARCH INPUT -->
        <input type="text" maxlength="540" placeholder="Search Recipes..."
          class="absolute text-center text-white placeholder:text-zinc-300 bg-transparent border border-zinc-400 w-60 outline-none rounded-lg"
          style="top: 1rem; right: 8rem;">

        <!-- !SECTION  -->
        <!-- SECTION Login Button -->
        <div x-data="{ openMenu: false }" class="absolute" style="right: 1rem;top: 0rem;">
          <button
            class="relative flex items-center text-white justify-center py-3 px5 space-x-3 border-2 border-zinc-400 w-24 h-5 rounded-full"
            style="right: 0rem;top: 1rem;">Search</button>
          <button v-if="!user.isAuthenticated" @click="login"
            class="absolute top-12 flex items-center text-white justify-center py-3 px5 space-x-3 border-2 border-zinc-400 w-24 h-5 rounded-full">Login<span
              class="absolute animate-ping inline-flex rounded-full h-3 w-3 bg-sky-500"
              style="right: .5rem;"></span></button>
              <button v-else x-on:click="openMenu = ! openMenu" id="menu-btn"
                class="absolute top-12 flex items-center text-white justify-center py-3 px5 space-x-3 border-2 border-zinc-400 w-24 h-5 rounded-full">Account
              </button>
              <div x-show="openMenu" x-on:click.outside="openMenu = false"
              x-transition:enter="transition ease-out duration-100"
      x-transition:enter-start="transform opacity-0 scale-95"
      x-transition:enter-end="transform opacity-100 scale-100"
      x-transition:leave="transition ease-in duration-75"
      x-transition:leave-start="transform opacity-100 scale-100"
      x-transition:leave-end="transform opacity-0 scale-95"
                class="absolute right-1 top-20 z-10 mt-2 w-56 origin-top-right divide-y divide-gray-100 rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none"
                role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                <div class="py-1" role="none">
                  <!-- Active: "bg-gray-100 text-gray-900", Not Active: "text-gray-700" -->
                  <p @click="openSlide" x-on:click="openMenu = false" class="text-gray-700 block px-4 py-2 text-sm hover:bg-indigo-500 hover:text-white" role="menuitem" tabindex="-1"
                    id="menu-item-0">Account Settings</p>
                  <p x-on:click="openMenu = false" class="text-gray-700 block px-4 py-2 text-sm hover:bg-indigo-500 hover:text-white" role="menuitem" tabindex="-1"
                    id="menu-item-1">Favorites</p>
                </div>
                <div class="py-1" role="none">
                  <p @click="logout" x-on:click="openMenu = false" class="text-gray-700 block px-4 py-2 text-sm hover:bg-indigo-500 hover:text-white" role="menuitem" tabindex="-1"
                    id="menu-item-2">Sign Out</p>

                </div>

              </div>

 
        </div>
        <!-- !SECTION -->


        <!-- SECTION TITLE AND HEADER -->
        <h1 class="text-4xl md:text-6xl text-white font-medium font-serif">All-Spice</h1>
        <p class="text-base text-slate-200 pt-1">Cherish Your Family</p>
        <p class="text-base text-slate-200">And Their Cooking</p>
        <!-- !SECTION -->
        <!-- SECTION NAV / FILTER BAR -->
        <div
          class="flex absolute space-x-10 px-3 py-1 bg-white border-2 shadow-md hover:bg-opacity-3 hover:shadow-lg hover:-translate-y-0.5 transition-all duration-150 rounded-xl"
          style="bottom: -1rem;">
          <button class="text-green-500">All</button>
          <button class="text-green-500">My Recipes</button>
          <button class="text-green-500">Favorites</button>
        </div>
        <!-- !SECTION -->
      </div>
    </div>
  </section>


  <section id="Recipes">
<!-- SECTION Recipe Card Template -->
<div class="grid-container px-4 pt-10 pb-5">
    <div v-for="recipe in recipes" :key="recipes.id" class="grid-item h-64 w-full bg-cover rounded-md hover:bg-opacity-3 hover:shadow-lg hover:-translate-y-1 transition-all duration-150" :style="{ 'background-image': `url(${recipe.img})` }">
      <div class="flex flex-col justify-between h-full">
        <div class="flex justify-between">
          <p class="glass-container text-white px-2">{{ recipe.category }}</p>
          <i class="mdi mdi-heart-outline text-lg"></i>
        </div>

        <p class="glass-container text-white px-2">{{ recipe.title }}</p>
      </div>
    </div>
  </div>
  </section>
  <div class="fixed bottom-4 right-4 z-9">
    <button type="button" class="rounded-full bg-indigo-600 p-2 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
  <svg class="h-8 w-8" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
    <path d="M10.75 4.75a.75.75 0 00-1.5 0v4.5h-4.5a.75.75 0 000 1.5h4.5v4.5a.75.75 0 001.5 0v-4.5h4.5a.75.75 0 000-1.5h-4.5v-4.5z" />
  </svg>
</button>

</div>
<!-- !SECTION -->
<AccountSlide v-model:open="open" v-bind:account="account" @close-slide="closeSlide" @submit-account="handleSubmit" />
</template>

<script>
import { computed, ref, onMounted } from 'vue'
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
import { logger } from "../utils/Logger.js";
import { recipeService } from '../services/RecipeService.js'
import { accountService } from "../services/AccountService.js";
import AccountSlide from '../components/AccountSlide.vue';
import Pop from "../utils/Pop.js";
export default {
  components:{
    AccountSlide,
  },
  setup() {
    const openAcct = ref(false)
    const filterBy = ref('')
    const openSlide = () => {
      openAcct.value = true; // Open the slide
    };
    // SECTION event handling for the accountslide component
    const closeSlide = () => {
      console.log('event closeSlide')
      openAcct.value = !openAcct.value; // Close the slide
    };
    async function handleSubmit(data){
      // Handle the submitted account data from the child component
      console.log('Submitted account:', data);
      // const { id, email, ...accountData } = data;
      try {
          Pop.toast('updating account')
          await accountService.editAccount(data)
        } catch (error) {
          Pop.error(error, '[Editing Account]')
        }
    };
// !SECTION end component event handlers


    onMounted(() => getRecipes())
    async function getRecipes() {
      try {
        await recipeService.getRecipes()

      } catch (error) {
        logger.log(error.message)
      }

    }
    return {
      openAcct,
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      recipes: computed (() => AppState.recipes),
      open: computed(() => openAcct.value),
      openSlide,
      closeSlide,
      handleSubmit,
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout()
      }
    }
  }
}
</script>

<style scoped lang="scss">
.grid-container {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  grid-gap: 20px;
}
.grid-item {
  background-color: #ccc;
  padding: 20px;
}
.glass-container{
  background: rgba(0, 0, 0, 0.4);
border-radius: 12px;
box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
backdrop-filter: blur(5px);
-webkit-backdrop-filter: blur(5px);
border: 1px solid rgba(0, 0, 0, 0.3);
}
</style>
