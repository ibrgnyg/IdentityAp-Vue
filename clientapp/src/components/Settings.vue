<template>
	<div class="container">

		<div class="row gutters-sm">
			<div class="col-md-4 d-none d-md-block">
				<div class="card">
					<div class="card-body">
						<nav class="nav flex-column nav-pills nav-gap-y-1">
							<router-link to="/profile" tag="li">
								<a data-toggle="tab" class="nav-item nav-link has-icon nav-link-faded active">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-user mr-2"><path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path><circle cx="12" cy="7" r="4"></circle></svg>Profile Information
								</a>

							</router-link>
							<router-link to="/settings" tag="li">
								<a  data-toggle="tab" class="nav-item nav-link has-icon nav-link-faded">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-settings mr-2"><circle cx="12" cy="12" r="3"></circle><path d="M19.4 15a1.65 1.65 0 0 0 .33 1.82l.06.06a2 2 0 0 1 0 2.83 2 2 0 0 1-2.83 0l-.06-.06a1.65 1.65 0 0 0-1.82-.33 1.65 1.65 0 0 0-1 1.51V21a2 2 0 0 1-2 2 2 2 0 0 1-2-2v-.09A1.65 1.65 0 0 0 9 19.4a1.65 1.65 0 0 0-1.82.33l-.06.06a2 2 0 0 1-2.83 0 2 2 0 0 1 0-2.83l.06-.06a1.65 1.65 0 0 0 .33-1.82 1.65 1.65 0 0 0-1.51-1H3a2 2 0 0 1-2-2 2 2 0 0 1 2-2h.09A1.65 1.65 0 0 0 4.6 9a1.65 1.65 0 0 0-.33-1.82l-.06-.06a2 2 0 0 1 0-2.83 2 2 0 0 1 2.83 0l.06.06a1.65 1.65 0 0 0 1.82.33H9a1.65 1.65 0 0 0 1-1.51V3a2 2 0 0 1 2-2 2 2 0 0 1 2 2v.09a1.65 1.65 0 0 0 1 1.51 1.65 1.65 0 0 0 1.82-.33l.06-.06a2 2 0 0 1 2.83 0 2 2 0 0 1 0 2.83l-.06.06a1.65 1.65 0 0 0-.33 1.82V9a1.65 1.65 0 0 0 1.51 1H21a2 2 0 0 1 2 2 2 2 0 0 1-2 2h-.09a1.65 1.65 0 0 0-1.51 1z"></path></svg>Account Settings
								</a>
							</router-link>

							<router-link to="/chancgepassword" tag="li">

								<a data-toggle="tab" class="nav-item nav-link has-icon nav-link-faded active">
									<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-shield mr-2"><path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"></path></svg>Security
								</a>

							</router-link>

						</nav>
					</div>
				</div>
			</div>
			<div class="col-md-8">
				<div class="card">

					<div class="card-body tab-content">
						<div class="tab-pane active" id="profile">
							<h6>ACCOUNT SETTINGS</h6>
							<hr>
							<form>
								<div class="form-group">
									<label for="username">Username</label>
									<input type="text" class="form-control" id="username" aria-describedby="usernameHelp" placeholder="Enter your username" value="kennethvaldez">
									<small id="usernameHelp" class="form-text text-muted">After changing your username, your old username becomes available for anyone else to claim.</small>
								</div>
								<hr>
								<div class="form-group">
									<label class="d-block text-danger">Delete Account</label>
									<p class="text-muted font-size-sm">Once you delete your account, there is no going back. Please be certain.</p>
								</div>
								<button class="btn btn-danger" type="button">Delete Account</button>
							</form>
						</div>

						<div class="tab-pane" id="account">
							
						</div>

					</div>
				</div>
			</div>
		</div>

	</div>
</template>
<script>
	export default {
		name: "settings",
		created: function () {
			if (localStorage.getItem("user-token") != null) {
			}
			else {
				this.$router.push({ path: "/login" });
			}
		}
	}
</script>