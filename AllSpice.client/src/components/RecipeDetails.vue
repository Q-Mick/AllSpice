<template>
  <TransitionRoot as="template" :show="open">
    <Dialog as="div" class="relative z-10" @close="toggleModal">
      <TransitionChild as="template" enter="ease-out duration-300" enter-from="opacity-0" enter-to="opacity-100"
        leave="ease-in duration-200" leave-from="opacity-100" leave-to="opacity-0">
        <div class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity" />
      </TransitionChild>

      <div class="fixed inset-0 z-10 overflow-y-auto">
        <div class="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:pr-0 ">
          <TransitionChild as="template" enter="ease-out duration-300"
            enter-from="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95"
            enter-to="opacity-100 translate-y-0 sm:scale-100" leave="ease-in duration-200"
            leave-from="opacity-100 translate-y-0 sm:scale-100"
            leave-to="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95">
            <DialogPanel
              class="relative transform overflow-hidden rounded-lg bg-white px-0 text-left shadow-xl transition-all min-w-[4/5] max-w-6xl max-h-[35rem]">

              <div>
                <div class="flex">
                  <img :src="recipe?.img" alt=""
                    class="aspect-square w-[28rem] h-auto object-center object-cover rounded-l-lg hidden lg:inline mr-1">
                  <div class="flex flex-col flex-grow">

                    <p class="font-semibold px-2 font-serif">{{ recipe?.title }}</p>

                    <div class="flex flex-row">

                      <div
                        class="flex flex-col border border-gray-950 m-1 rounded-md w-1/2 sm:w-[50%] overflow-hidden min-h-[20rem]">
                        <div class="bg-green-600 text-white font-normal text-center font-serif">
                          Recipe steps
                        </div>
                        <div class="overflow-auto">

                          <p v-for="(step, index) in recipe.steps" :key="index" class="text-[16px] mx-2"><span
                              @click="removeStep(index)" v-if="account?.id == recipe?.creatorId"
                              class="cursor-pointer text-red-500">X</span>
                            {{ index + 1 }}. {{ step }}
                          </p>
                        </div>

                        <div v-if="account?.id == recipe?.creatorId" class="mt-auto relative flex items-center m-1">
                          <input v-model="newStep" type="text" name="step" id="step"
                            class="block w-full rounded-md border-0 py-1.5 h-9 pr-14 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" />
                          <div @click="addStep(newStep)" class="absolute inset-y-0 right-0 flex py-1.5 pr-1.5">
                            <kbd
                              class="inline-flex items-center rounded border border-gray-200 px-1 font-sans text-xs text-gray-400 cursor-pointer">➕</kbd>
                          </div>
                        </div>

                      </div>

                      <div
                        class="flex flex-col border border-gray-950 m-1 rounded-md w-1/2 sm:w-[50%] overflow-hidden min-h-[20rem]">
                        <div class="bg-green-600 text-white font-normal text-center font-serif">
                          Recipe Ingredients
                        </div>
                        <div class="overflow-auto">
                          <!-- <p v-for="(step, index) in recipe.steps" :key="index" class="text-[16px] mx-2">
                            {{ index + 1 }}. {{ step }}
                          </p> -->
                        </div>
                        <div class="flex-grow mt-auto"></div>

                        <div v-if="account?.id == recipe?.creatorId" class="relative flex items-center m-1 space-x-1">
                          <label for="Qty"
                            class="absolute top-[-12px] left-3 bg-white block text-sm font-medium leading-6 text-gray-900">Qty</label>
                          <select v-model="newIngredient.quantity" id="location" name="location"
                            class="w-16 py-0 m-0 h-9 block rounded-md text-gray-900 ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-indigo-600 sm:text-sm sm:leading-6">
                            <option selected="">1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>
                            <option>6</option>
                            <option>7</option>
                            <option>8</option>
                            <option>9</option>
                          </select>
                          <input v-model="newIngredient.name" type="text" name="step" id="step"
                            class="relative w-full rounded-md border-0 py-1.5 h-9  text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" />
                          <button type="button"
                            class="rounded-full bg-indigo-600 p-2 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">
                            <PlusIcon class="h-5 w-5" aria-hidden="true" />
                          </button>
                        </div>
                        <div class="">

                        </div>
                      </div>
                    </div>
                    <div class="flex-grow"></div>

                    <div class="mb-1 mx-1 mt-aut flex justify-end space-x-2">

                      <button v-if="account?.id == recipe?.creatorId" type="button"
                        class="inline-flex w-1/2  justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                        @click="saveRecipe">Save recipe</button>
                      <button type="button"
                        class="inline-flex w-1/2  justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                        @click="toggleModal">Go back to dashboard</button>
                    </div>
                  </div>
                </div>
              </div>
            </DialogPanel>
          </TransitionChild>
        </div>
      </div>
    </Dialog>
  </TransitionRoot>
</template>
<!-- <div class="relative">
  <label for="Qty" class="absolute top-[-3px] left-2 bg-white block text-sm font-medium leading-6 text-gray-900">Qty</label>
  <select v-model="newIngredient.quantity" id="location" name="location" class="mt-2 block w-full rounded-md border-0 py-1.5 pl-3 pr-10 text-gray-900 ring-1 ring-inset ring-gray-300 focus:ring-2 focus:ring-indigo-600 sm:text-sm sm:leading-6">
    <option selected="">1</option>
    <option>2</option>
    <option>3</option>
    <option>4</option>
    <option>5</option>
    <option>6</option>
    <option>7</option>
    <option>8</option>
    <option>9</option>
  </select>
</div> -->

<script setup>
import { ref } from 'vue'
import { Dialog, DialogPanel, DialogTitle, TransitionChild, TransitionRoot } from '@headlessui/vue'
import { PlusIcon } from '@heroicons/vue/20/solid'
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";


const props = defineProps({
  open: Boolean,
  recipe: Object,
  account: Object,
})
const newIngredient = ref({})
const newStep = ref("")
const emit = defineEmits(['toggle-details', 'update-recipe']);
const toggleModal = () => {
  emit('toggle-details');
}

function addStep() {
  const stepToAdd = newStep.value
  newStep.value = ""
  AppState.activeRecipe.steps.push(stepToAdd)
}
function removeStep(index) {
  AppState.activeRecipe.steps.splice(index, 1)
}
function saveRecipe() {
  const newInstructions = AppState.activeRecipe.steps.join(" + ")
  AppState.activeRecipe.instructions = newInstructions
  emit('update-recipe')
  logger.log(newInstructions)

}
</script>


<style lang="scss" scoped></style>