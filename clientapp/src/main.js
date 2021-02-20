import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Router from 'vue-router'
import Register from "./components/Register.vue"
import Login from "./components/Login.vue"
import Profile from "./components/Profile.vue"
import Forgot from "./components/ForgotPsw.vue"
import Home from "./components/Home.vue"
import Chancge from "./components/ChancgePsw.vue"
import Settings from "./components/Settings.vue"
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import Notification from 'vue-notification'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import { NavbarPlugin } from 'bootstrap-vue'
import Vuelidate from 'vuelidate'

Vue.use(Vuelidate)
Vue.use(NavbarPlugin)
Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(Notification)
Vue.use(Router)
Vue.use(VueAxios, axios)
Vue.config.productionTip = false



const router = new Router({
	routes: [
		{ path: '/Register', component: Register },
		{ path: '/Login', component: Login },
		{ path: '/Profile', component: Profile },
		{ path: '/ForgotPassword', component: Forgot },
		{ path: '/', component: Home, },
		{ path: '/chancgepassword', component: Chancge, name: "/chancgepassword" },
		{ path: '/settings', component: Settings, name: "/settings" },
	],
	
	mode:'history'

})

new Vue({
	el: "#app",
	render: h => h(App),
	router
})
