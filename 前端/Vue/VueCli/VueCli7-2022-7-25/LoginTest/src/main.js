import { createApp } from 'vue'
import App from './App.vue'
import router from './components/Main'
import './assets/bootstrap.css'
import './index.css'
 
const app = createApp(App);
app.use(router);
app.mount("#app");
