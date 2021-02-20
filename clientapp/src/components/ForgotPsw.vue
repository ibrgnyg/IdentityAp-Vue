<template>
	<div>
		<div class="container">
			<div class="row gutters-sm">
				<div class="col-md-8">
					<div class="card">
						
						<div class="card-body tab-content">

							<div class="tab-pane" id="security">
								<h6>SECURITY SETTINGS</h6>
								<hr>
								<form>
									<div class="form-group">
										<label class="d-block">Change Password</label>
										<input type="text" class="form-control" placeholder="Enter your old password">
										<input type="text" class="form-control mt-1" placeholder="New password">
										<input type="text" class="form-control mt-1" placeholder="Confirm new password">
									</div>
								</form>
								<hr>
								<form>
									<div class="form-group">
										<label class="d-block">Two Factor Authentication</label>
										<button class="btn btn-info" type="button">Enable two-factor authentication</button>
										<p class="small text-muted mt-2">Two-factor authentication adds an additional layer of security to your account by requiring more than just a password to log in.</p>
									</div>
								</form>
								<hr>
								<form>
									<div class="form-group mb-0">
										<label class="d-block">Sessions</label>
										<p class="font-size-sm text-secondary">This is a list of devices that have logged into your account. Revoke any sessions that you do not recognize.</p>
										<ul class="list-group list-group-sm">
											<li class="list-group-item has-icon">
												<div>
													<h6 class="mb-0">San Francisco City 190.24.335.55</h6>
													<small class="text-muted">Your current session seen in United States</small>
												</div>
												<button class="btn btn-light btn-sm ml-auto" type="button">More info</button>
											</li>
										</ul>
									</div>
								</form>
							</div>


						</div>
					</div>
				</div>
			</div>

		</div>

	</div>
</template>


<script>
	import { required, email } from 'vuelidate/lib/validators';
	export default {
		name: "Forgot",
		created: function () {
			if (localStorage.getItem("user-token") != null) {
			}
			else {
				this.$router.push({ path: "/login" });
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
		background: rgba(0, 0, 0, .8);
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
		background: #ffa502;
		top: .5rem;
		left: 50%;
		height: calc(50% - .5rem);
		width: 110%;
		z-index: 9999;
		padding: 1.5rem;
		box-shadow: 0 0 8px 1px rgba(0,0,0,.5);
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
			background: transparent;
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