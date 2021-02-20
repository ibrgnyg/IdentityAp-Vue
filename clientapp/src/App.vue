<template>
	<div id="app">
		<Header />

		<notifications group="foo" />

		<router-view></router-view>

		<Footer/>
	</div>
</template>
<script>
	import Header from './Layout/Header.vue'
	import Footer from './Layout/Footer.vue'
	export default {
		name: 'App',
		components: {
			Header,
			Footer,

		}

	}
</script>

<!--  <div>
	<div class="mt-3">
		<b-button-group>
			<b-button variant="outline-primary"><router-link to="/login">Login</router-link></b-button>
			<b-button variant="outline-primary">	<router-link to="/register">Register</router-link></b-button>

		</b-button-group>
	</div>
</div>       -->
