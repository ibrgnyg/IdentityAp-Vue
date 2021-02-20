<template>
	<div class="container">

		<div class="modal-box">
			<div class="auth">

				<div class="shutter login">
					<button id="buttonLoginRegister" @click="LoginPage">Login</button>
				</div>
				<div id="register" class="register-card">
					<h2>Register</h2>					
					<div id="registerForm" class="">
						<div class="form-group ">
							<label>username</label>
							<div class="error" style="color:red" v-if="!$v.username.minLength">UserName must have at least {{$v.username.$params.minLength.min}} letter!</div>
							<b-form-input class="form-control" type="text" v-model.trım="$v.username.$model" :class="{'is-invalid':$v.username.$error, 'is-valid':!$v.username.$invalid}"></b-form-input>
						</div>

						<div class="form-group ">
							<label>email</label>
							<div style="color:red" v-if="!$v.email.email">Email is required!</div>
							<b-form-input class="form-control" type="text" v-model.trım="$v.email.$model" :class="{'is-invalid':$v.email.$error, 'is-valid':!$v.email.$invalid}"></b-form-input>
						</div>

						<div class="form-group ">
							<label>password</label>
							<div class="error" style="color:red" v-if="!$v.password.minLength">Password must have at least {{$v.password.$params.minLength.min}} figure!</div>
							<b-form-input class="form-control" type="text" v-model.trım="$v.password.$model" :class="{'is-invalid':$v.password.$error, 'is-valid':!$v.password.$invalid}"></b-form-input>
						</div>

						<div class="row">
							<div class="col-md-4">
								<button type="button" class="btn btn-info" v-on:click="Register" :disabled="submitStatus === 'PENDING'">Register</button>
							</div>
							<div class="col-md-4 offset-md-4" v-if="show">
								<router-link to="/login"><u>Now login</u></router-link>
							</div>
						</div>
					</div>
				</div>

			</div>
			
		</div>

</div>
</template>

<script>
	import axios from 'axios';
	import Vue from 'vue';
	import { required, email,  minLength } from 'vuelidate/lib/validators';
	export default {
		name: 'Register',
		data() {
			return {
				username: "",
				email: "",
				password: "",
				show: false,
				submitStatus: null
			};
		},
		methods: {
			Register() {
				var vm = this;
				this.$v.$touch()
				if (this.$v.$invalid) {
					this.submitStatus = 'ERROR'
				}
				else {
					axios({
						method: 'post',
						url: '/api/account/register',
						data: {
							username: this.username,
							email: this.email,
							password: this.password,
						}
					})
						.then(function () {
							Vue.notify({
								group: 'foo',
								type: 'success',
								duration: 2500,
								title: "Succes",
								text: 'registered successfully'
							})
							vm.show = true;
							vm.username = "";
							vm.email = "";
							vm.password = "";
						})
						.catch(function () {
							Vue.notify({
								group: 'foo',
								type: 'error',
								duration: 2500,
								title: "Error",
								text: 'email or name already been used ',
							})
						})
				}
			},
			LoginPage() {
				this.$router.push({ path: "/login" });
			}

		},
		validations: {
			username: {
				required,
				minLength: minLength(4)

			},
			email: {
				required,
				email
			},
			password: {
				required,
				minLength: minLength(4)
			}
		
		}
		
	
	}
</script>


<style>
	/* Rester */
	* {
		box-sizing: border-box;
	}

	html {
		font-family: sans-serif;
		font-size: 2.3vmax;
	}

	body {
		margin: 0;
		padding: 0;
	}

	button, button:hover, button:focus {
		outline: none;
		cursor: pointer;
		user-select: none;
	}

	h1, h2, h3, h4, h5, h6 {
		magin: 0;
		padding: 0;
	}

	/* Helpers */
	.buttonGoogleAccount {
		border: none;
		padding: .3rem;
		border-radius: .18rem;
		color: #FFF;
		background: #EA4335;
	}

	/* Mobil - First */
	button {
		font-size: .7rem;
	}

	.container {
		display: flex;
		flex-flow: row nowrap;
		justify-content: center;
		align-items: center;
		height: 100vh;
		width: 100vw;
		background:#ffffff!important;
	}

	.modal-box {
		position: relative;
		paddind: 1.8rem;
		background: #fff;
		border-radius: .2rem;
	}

	.shutter {
		display: flex;
		justify-content: center;
		position: absolute;
		background: #827a6c!important;
		top: .5rem;
		left: 50%;
		height: calc(50% - .5rem);
		width: 110%;
		z-index: 9999;
		padding: 1.5rem;
		border-radius: 10px;
		box-shadow: 0 0 8px 1px rgba(255,255,255,.5) !important;
		transition: transform .2s;
	}

		.shutter.register {
			transform: translate(-50%, 0);
			align-items: flex-start;
		}

		.shutter.login {
			transform: translate(-50%, 100%);
			align-items: flex-end;
		}

		.shutter > button {
			padding: .5rem 2rem;
			border-radius: .3rem;
			border: .15rem solid #fff;
			background: o;
			height: max-content;
			color: #fff;
			font-weight: bold;
			transition: background .2s, border-color .2s, color .2s;
		}

			.shutter > button:hover, .shutter > button:focus {
				background: #fff;
				color: #ff4757;
				border-color: transparent;
			}

	.auth {
		display: grid;
		grid-template: 1fr 1fr/ 1fr;
		align-items: space-between;
		padding: .5rem;
		background-color: #b5b5b5;
		border-radius:10px;
	}

	.register-card, .login-card {
		display: flex;
		flex-flow: column nowrap;
		justify-content: space-around;
		min-height: 11rem;
		width: 13rem;
	}

	.register-card {
		margin-top: .3rem;
	}

	.login-card {
		margin-bottom: .3rem;
	}

	.auth > form {
		display: flex;
		flex-flow: column nowrap;
	}

	.inputWrapper {
		position: relative;
		margin: .4rem 0;
	}

		.inputWrapper > label {
			position: absolute;
			display: block;
			width: 100%;
			hieght: max-content;
			left: 0;
			top: 0;
			font-size: .8rem;
			color: grey;
			user-select: none;
			transition: transform .2s, font-size .2s, color .2s, opacity .2s;
		}

		.inputWrapper > input:focus ~ label {
			transform: translate(0%, -80%);
			font-size: .6rem;
			color: #ff6348;
		}

		.inputWrapper > input[type="text"],
		.inputWrapper > input[type="password"],
		.inputWrapper > input[type="email"] {
			border: none;
			border-bottom: .1rem solid #ff7f50;
			width: 100%;
			padding: .25rem;
			background: transparent;
			color: #ff7f50;
			font-weight: bold;
			font-size: .7rem;
		}

			.inputWrapper > input[type="text"]:focus,
			.inputWrapper > input[type="password"]:focus,
			.inputWrapper > input[type="email"]:focus {
				outline: none;
				border-bottom-color: #ff4757;
			}

	button[type="submit"] {
		border: none;
		width: 100%;
		padding: .5rem;
		border-radius: .2rem;
		color: #fff;
		background: #ff7f50;
		font-weight: bold;
		cursor: pointer;
		user-select: none;
		transition: background .4s ease-in-out;
	}

		button[type="submit"]:hover,
		button[type="submit"]:focus {
			background: #ff4757;
		}

	/* small */
	@media screen and (min-width: 519px) {
		html {
			font-size: 2.5vmax;
		}

		button {
			font-size: 8.rem;
		}

		.auth {
			grid-template: 1fr / 1fr 1fr;
		}

		.shutter {
			width: 14rem;
			height: 110%;
			top: 50%;
			left: .5rem;
		}

			.shutter.register {
				transform: translate(0%, -50%);
			}

			.shutter.login {
				transform: translate(16rem, -50%);
			}

		.register-card {
			margin-top: 0;
			margin: 1rem;
		}

		.login-card {
			margin-bottom: 0;
			margin: 1rem;
		}

		.inputWrapper > input[type="text"],
		.inputWrapper > input[type="password"],
		.inputWrapper > input[type="email"] {
			margin: .5rem 0;
		}
	}

	@media screen and (min-width: 572px) {
		html {
			font-size: 2vmax;
		}
	}

	@media screen and (min-width: 768px) {
		html {
			font-size: 1.6vmax;
		}
	}

	@media screen and (min-width: 992px) {
		html {
			font-size: 1.2vmax;
		}
	}

	@media screen and (min-width: 1200px) {
		html {
			font-size: 1vmax;
		}
	}
</style>
