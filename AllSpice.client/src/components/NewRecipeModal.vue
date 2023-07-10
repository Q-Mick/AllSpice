<template>
  <TransitionRoot as="template" :show="open">
    <Dialog as="div" class="relative z-10" @close="toggleModal">
      <TransitionChild as="template" enter="ease-out duration-300" enter-from="opacity-0" enter-to="opacity-100"
        leave="ease-in duration-200" leave-from="opacity-100" leave-to="opacity-0">
        <div class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity" />
      </TransitionChild>

      <div class="fixed inset-0 z-10 overflow-y-auto">
        <div class="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">
          <TransitionChild as="template" enter="ease-out duration-300"
            enter-from="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95"
            enter-to="opacity-100 translate-y-0 sm:scale-100" leave="ease-in duration-200"
            leave-from="opacity-100 translate-y-0 sm:scale-100"
            leave-to="opacity-0 translate-y-4 sm:translate-y-0 sm:scale-95">
            <DialogPanel
              class="relative transform overflow-hidden  bg-white text-left shadow-xl transition-all min-w-[30rem]">
              <!-- modal guts here -->

              <div class="bg-green-700 text-white font-seriff text-2xl font-thin py-2 px-2">
                New Recipe
              </div>
              <div class="flex flex-row">
                <!-- title -->
                <div class="px-2 w-1/2">
                  <label for="title" class="block text-sm font-medium leading-6 text-gray-900">Title</label>
                  <div class="mt-2">
                    <input type="title" name="title" id="title"
                      class="block w-full rounded-md border-0 px-1 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                      placeholder="Title..." />
                  </div>
                </div>

                <!-- category -->
                <div class="px-2 w-1/2">
                  <label for="email" class="block text-sm font-medium leading-6 text-gray-900">Category</label>
                  <div class="mt-2">
                    <input type="category" name="category" id="category"
                      class="block w-full rounded-md border-0 px-1 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                      placeholder="Category" />
                  </div>
                </div>
              </div>
              <!-- description -->
              <div class="px-2">
    <label for="email" class="block text-sm font-medium leading-6 text-gray-900">Description</label>
    <div class="mt-2">
      <input type="description" name="description" id="description" class="px-1 block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6" placeholder="It tastes so good..." aria-describedby="email-description" />
    </div>
    <p class="mt-2 text-sm text-gray-500" id="email-description">Brief description of the recipe.</p>
  </div>
              <!-- buttons here -->
              <div class="mt-5 sm:mt-6 p-2 flex justify-end mt-5 sm:mt-6 items-end space-x-1">
                <button type="button" class="rounded bg-white px-2.5 py-1 text-sm font-semibold text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50">Cancel</button>
                <button type="button" class="rounded bg-indigo-600 px-2 py-1 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Create Recipe</button>
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

// const open = ref(true)
const props = defineProps({
  open: Boolean,
})
const emit = defineEmits(['toggle-create-recipe']);
const toggleModal = () => {
  emit('toggle-create-recipe');
}
</script>


<style lang="scss" scoped></style>