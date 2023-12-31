import '@mdi/font/css/materialdesignicons.css'

import { createApp } from 'vue'
// @ts-ignore
import App from './App.vue'
import { registerGlobalComponents } from './registerGlobalComponents'
import { router } from './router'
import './utils/SocketProvider.js'
import Alpine from 'alpinejs'
 
window.Alpine = Alpine
 
Alpine.start()
const root = createApp(App)
registerGlobalComponents(root)

root
  .use(router)
  .mount('#app')
