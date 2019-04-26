using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SqlManagedIdentityDemo.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			try
			{
				using var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

				//connection.AccessToken = await new AzureServiceTokenProvider().GetAccessTokenAsync("https://database.windows.net/");

				connection.Open();

				using var cmd = new SqlCommand("SELECT suser_name()", connection);

				var sqlUser = await cmd.ExecuteScalarAsync();

				return View(sqlUser);
			}
			catch
			{
				return View((object)"FAIL");
			}
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