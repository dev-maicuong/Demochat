using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demochat.Hubs;
using Demochat.Models;

namespace Demochat.Controllers
{
    
    public class HomeController : Controller
    {
        TestrealTimeMessageEntities db = new TestrealTimeMessageEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
        public JsonResult Get()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestrealTimeMessage"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [id_mess],[mess_content],[id_user],[id_userSend]FROM [dbo].[Message]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    List<Message> Chat = db.Messages.ToList();
                    List<mess> listChat = Chat.Select(n => new mess
                    {
                        id_mess = n.id_mess,
                        mess_content = n.mess_content
                    }).ToList();
                    return Json(new { listChat = listChat }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            DemoChat.Message();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}