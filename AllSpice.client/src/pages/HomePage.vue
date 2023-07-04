<template>
  <section id="hero">
  <div class="relative h-[20rem] md:h-[25rem] w-full bg-cover bg-center" style="background-image: url('https://images.unsplash.com/photo-1564149504298-00c351fd7f16?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80')">
    
  <div class="flex-col absolute inset-0 bg-black bg-opacity-50 flex items-center justify-center">
    <!-- SEARCH INPUT -->
    <input 
    type="text"
    maxlength="540"
    placeholder="Search..."
    class="absolute text-center text-white placeholder:text-zinc-300 bg-transparent border border-zinc-400 w-60 outline-none" style="top: 1rem; right: 1rem;">
  
    <h1 class="text-4xl md:text-6xl text-white font-medium font-serif">All-Spice</h1>
    <p class="text-base text-slate-200 pt-1">Cherish Your Family</p>
    <p class="text-base text-slate-200">And Their Cooking</p>
  </div>
</div>
</section>
</template>

<script>
export default {
  setup() {
    return {}
  }
}
</script>

<style scoped lang="scss">

</style>
