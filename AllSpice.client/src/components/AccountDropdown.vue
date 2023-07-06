<template>
<button class="block h-8 w-8 rounded-full overflow-hidden border-2 border-zinc-400 focus:outline-none focus:border-white">
  <img class="h-full w-full object-cover" :src="account.picture" alt="">
</button>  
</template>


<script>
import { Account } from "../models/Account.js";

export default {
  props: {
    account: { type: Account, required: true },
  },
  setup(){
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>