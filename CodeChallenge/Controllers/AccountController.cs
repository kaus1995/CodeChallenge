using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace CodeChallenge.Controllers
{
    public class AccountController : Controller
    {
        // Sends an OpenIDConnect Sign-In Request.  
        public void SignIn()
        {
            if (!Request.IsAuthenticated)
            {

                HttpContext.GetOwinContext()
                    .Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
                        OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }


        // Signs the user out and clears the cache of access tokens.  
        public void SignOut()
        {

            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);

        }


    }
}