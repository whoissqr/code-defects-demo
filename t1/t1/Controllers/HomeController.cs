using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.IO;

namespace t1.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = string.Empty;

        //uncomment to fix the CSRF defect
        //[ValidateAntiForgeryToken]
        public bool Attack(Employee worker)
        {
            string name = worker.Name;
            string sql = "insert into Comments(productCode) values ('" + name + "');";
            _connectionString = string.Format("Data Source={0};Version=3", "c:\\mydb.db;");

            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        //--- uncomment to trigger a DEADCODE defect
        //int deadFunc()
        //{
        //    int a = 1, b = 0;
        //    return (a / b);
        //}

        public ActionResult Index()
        {
            return View();
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