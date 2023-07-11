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
              class="relative transform overflow-hidden rounded-lg bg-white px-0 text-left shadow-xl transition-all max-w-[65rem] max-h-[35rem]">

              <div>
                <div class="flex">
                  <img :src="recipe?.img" alt=""
                    class="aspect-square w-[28rem] h-auto object-center object-cover rounded-l-lg hidden lg:inline mr-1">
                  <div class="flex flex-col flex-grow">

                    <p class="font-semibold px-2 font-serif">{{ recipe?.title }}</p>

                    <div class="flex flex-row">

                      <div class="flex flex-col border border-gray-950 m-1 rounded-md w-[50%] overflow-hidden min-h-[20rem]">
                        <div class="bg-green-600 text-white font-normal text-center font-serif">
                          Recipe steps
                        </div>
                        <div class="overflow-auto">
                          <p v-for="(step, index) in recipe.steps" :key="index" class="text-[16px] mx-2">
                            {{ index + 1 }}. {{ step }}
                          </p>
                        </div>
             
                        <div v-if="account?.id == recipe?.creatorId" class="mt-auto relative flex items-center m-1">
                          <input type="text" name="step" id="step"
                            class="block w-full rounded-md border-0 py-1.5 h-9 pr-14 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" />
                          <div class="absolute inset-y-0 right-0 flex py-1.5 pr-1.5">
                            <kbd
                              class="inline-flex items-center rounded border border-gray-200 px-1 font-sans text-xs text-gray-400 cursor-pointer">➕</kbd>
                          </div>
                        </div>

                      </div>

                      <div class="flex flex-col border border-gray-950 m-1 rounded-md w-[50%] overflow-hidden min-h-[20rem]">
                        <div class="bg-green-600 text-white font-normal text-center font-serif">
                          Recipe Ingredients
                        </div>
                        <div class="overflow-auto">
                          <!-- <p v-for="(step, index) in recipe.steps" :key="index" class="text-[16px] mx-2">
                            {{ index + 1 }}. {{ step }}
                          </p> -->
                        </div>
                        <!-- <div class="flex-grow"></div> -->
                        <div v-if="account?.id == recipe?.creatorId" class="mt-auto relative flex items-center m-1">
                          <input type="text" name="step" id="step"
                            class="block w-full rounded-md border-0 py-1.5 h-9 pr-14 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" />
                          <div class="absolute inset-y-0 right-0 flex py-1.5 pr-1.5 cursor-pointer">
                            <kbd
                              class="inline-flex items-center rounded border border-gray-200 px-1 font-sans text-xs text-gray-400">➕</kbd>
                          </div>
                        </div>

                      </div>
                    </div>
                    <div class="flex-grow"></div>

                    <div class="mb-1 mx-1 mt-auto">
                      <button type="button"
                        class="inline-flex w-full justify-center rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
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


<script setup>
import { ref } from 'vue'
import { Dialog, DialogPanel, DialogTitle, TransitionChild, TransitionRoot } from '@headlessui/vue'
import { CheckIcon } from '@heroicons/vue/24/outline'
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";


const props = defineProps({
  open: Boolean,
  recipe: Object,
  account: Object,
})
const emit = defineEmits(['toggle-details']);
const toggleModal = () => {
  emit('toggle-details');
}
</script>


<style lang="scss" scoped></style>