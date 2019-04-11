using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bigschool_QuangIdol.Models;
using System.Data.Entity;
using Bigschool_QuangIdol.Models.ViewModels;

namespace Bigschool_QuangIdol.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbcontext;
        public HomeController()
        {
            dbcontext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourses = dbcontext.Courses
            .Include(c => c.Lecturer)
            .Include(c => c.Category)
            .Where(c => c.DateTime > DateTime.Now);


            var viewModel = new CourseViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
         
            };

            return View(viewModel); ;
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