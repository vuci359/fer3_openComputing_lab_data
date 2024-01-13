let auth0Client = null;
const fetchAuthConfig = () => fetch("./auth_config.json");

const configureClient = async () => {
    const response = await fetchAuthConfig();
    const config = await response.json();
  
    auth0Client = await auth0.createAuth0Client({
      domain: config.domain,
      clientId: config.clientId
    });
};

const updateUI = async () => {
    const isAuthenticated = await auth0Client.isAuthenticated();
  
    document.getElementById("btn-logout").disabled = !isAuthenticated;
    document.getElementById("btn-login").disabled = isAuthenticated;

    if (isAuthenticated) {
        document.getElementById("gated-content").classList.remove("hidden");
    
       // document.getElementById("ipt-access-token").innerHTML = await auth0Client.getTokenSilently();
          
        let user = await auth0Client.getUser();
        //document.getElementById("ipt-user-profile").textContent = JSON.stringify(user);
        document.getElementById("nickname").textContent = user.nickname;
        document.getElementById("name").textContent = user.name;
        document.getElementById("picture").src = user.picture;
        document.getElementById("updated_at").textContent = user.updated_at;
        document.getElementById("email").textContent = user.email;
        document.getElementById("email_verified").textContent = user.email_verified;
        document.getElementById("sub").textContent = user.sub;

    
      } else {
        document.getElementById("gated-content").classList.add("hidden");
      }

  };

  const login = async () => {
    await auth0Client.loginWithRedirect({
      authorizationParams: {
        redirect_uri: window.location.origin
      }
    });
  };

  const logout = () => {
    auth0Client.logout({
      logoutParams: {
        returnTo: window.location.origin
      }
    });
  };

  window.onload = async () => {
    await configureClient();
    // .. code ommited for brevity
    updateUI();
  
    const isAuthenticated = await auth0Client.isAuthenticated();
  
    if (isAuthenticated) {
      // show the gated content
      return;
    }
  
    // NEW - check for the code and state parameters
    const query = window.location.search;
    if (query.includes("code=") && query.includes("state=")) {
  
      // Process the login state
      await auth0Client.handleRedirectCallback();
      
      updateUI();
  
      // Use replaceState to redirect the user away and remove the querystring parameters
      window.history.replaceState({}, document.title, "/");
    }
  };

