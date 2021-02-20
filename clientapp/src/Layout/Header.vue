<template>

	<div>
		<b-navbar type="dark" variant="dark">
			<b-navbar-nav>
				<b-nav-item><router-link to="/">Home</router-link></b-nav-item>

				<!--<b-nav-item-dropdown text="Lang" right>
					<b-dropdown-item href="#">EN</b-dropdown-item>
					<b-dropdown-item href="#">ES</b-dropdown-item>
					<b-dropdown-item href="#">RU</b-dropdown-item>
					<b-dropdown-item href="#">FA</b-dropdown-item>
				</b-nav-item-dropdown>-->

				<b-nav-item-dropdown text="Account" left>
					<b-dropdown-item><router-link to="/login">Login</router-link></b-dropdown-item>
					<b-dropdown-item><router-link to="/register">Register</router-link></b-dropdown-item>
				</b-nav-item-dropdown>

				<b-col col lg="2" v-if="isToken"><b-nav-item @click="Log">LogOut</b-nav-item></b-col>

			</b-navbar-nav>
		</b-navbar>
	</div>
</template>

<script>
	import axios from 'axios';
	export default {
		name: "Header",
		data() {
			return {
				isToken: false,
			}
		},
		methods: {
			Log() {
				localStorage.removeItem("user-token");
				this.$router.push({ path: "/login" });
				location.reload();
			}
		},
		created: function () {
			if (localStorage.getItem("user-token") != null) {
				this.isToken = true;
			}
			else {
				this.isToken = false;

			}

			

		}
	}
</script>