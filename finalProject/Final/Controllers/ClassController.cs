using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final.Models.DB;
using Final.Models.ViewModel;
using Final.Models.EntityManager;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Web.Security;



namespace Final.Controllers
{
    public class ClassController : Controller
    {

        private CE_WebEntities db = new CE_WebEntities();

        public ActionResult ViewClasses()
        {
            return View();
        }

        public ActionResult EnrollClass() {
            var classes = db.classMasters.Include(o => o.className);
            ViewBag.classID = new SelectList(db.classMasters, "classID", "className");

            UserManager UM = new UserManager();
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name

            if (authCookie == null) { ViewBag.hasCookie = 0; } else { ViewBag.hasCookie = 1; }

            return View();

        }

        [HttpPost]
        public ActionResult ViewClasses(classMaster newClass)
        {
            ClassManager CM = new ClassManager();
            CM.AddClass(newClass);
            return View();
        }

        [HttpPost]
        public ActionResult Enroll(int ClassID) {

            UserManager UM = new UserManager();
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name;
            int UserID = UM.GetUserID(UserName);


            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CE_WebConnection"].ConnectionString;

            SqlParameter @userID = new SqlParameter();
            @userID.ParameterName = "userID";
            @userID.SqlDbType = SqlDbType.Int;
            @userID.IsNullable = false;
            @userID.Value = UserID;


            SqlParameter @classID = new SqlParameter();
            @classID.ParameterName = "classID";
            @classID.SqlDbType = SqlDbType.Int;
            @classID.IsNullable = false;
            @classID.Value = ClassID;

            object[] parameters = new object[] { @userID,@classID };
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[mvc].[SaveEnrollment]", conn);
                cmd.Parameters.AddRange(parameters);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

            }

            return View();
        }

        public DataTable UserClassData(int UserID)
        {
            DataTable results = new DataTable();
            string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CE_WebConnection"].ConnectionString;

            SqlParameter @userID = new SqlParameter();
            @userID.ParameterName = "userID";
            @userID.SqlDbType = SqlDbType.Int;
            @userID.IsNullable = false;
            @userID.Value = UserID;

            object[] parameters = new object[] { @userID };
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[mvc].[RetrieveClassesForStudent]", conn);
                cmd.Parameters.AddRange(parameters);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

            }

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                results = ds.Tables[0];
            }

            return results;
        }

        public ActionResult GetUserClasses() {
            var model = new List<ClassMaster>();
            string UserName = "";

            UserManager UM = new UserManager();
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name

            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                UserName = ticket.Name;
            }
            int UserID = UM.GetUserID(UserName);


            var classRecords = UserClassData(UserID);

            foreach (DataRow row in classRecords.Rows) {
                var thisClass = new ClassMaster();
                thisClass.className = row["className"].ToString();
                thisClass.classDescription = row["classDescription"].ToString();
                thisClass.classPrice = Decimal.Parse(Convert.ToString(row["classPrice"]));
                thisClass.classSessions = Int32.Parse(Convert.ToString(row["classSessions"]));
                model.Add(thisClass);
            }
            return View(model);
        }

    }
}