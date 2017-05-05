using System.Web.Mvc;
using System.Web.Security;
using Final.Models.ViewModel;
using Final.Models.EntityManager;
using System.Web;

namespace Final.Controllers
{
    public class PermissionsController : Controller
    {
        // GET: Permissions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authenticate()
        {
            return View();
        }

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string UserName, string UserPassword) {
            UserManager UM = new UserManager();
            User newUser = new User();
            newUser.userName = UserName;
            newUser.userPassword = UserPassword;
            UM.AddUser(newUser);
            return RedirectToAction("Authenticate", "Permissions");
        }

        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Authenticate(string userName, string userPassword)
        {
            UserManager UM = new UserManager();
            if (UM.GetUser(userName, userPassword))
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                
                string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                string UserName = ticket.Name;

                var localUserID  = UM.GetUserID(UserName);
                //ViewBag.Message = "Login Successful:" + FormsAuthentication.FormsCookieName + " :"+ UserName + ' userID: '+ localUserID;
                ViewBag.Message = "Login Successful. UserID:" + localUserID;

                return RedirectToAction("GetUserClasses", "Class", new {id= localUserID}); 
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View();
        }

    }
}