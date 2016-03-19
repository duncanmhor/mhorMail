using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MhorMail.Model;
using MhorMail.Services.Abstract;

namespace MhorMail.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MailServerConfiguration()
        {
            ServerConfiguration config = _adminService.GetCurrentServerConfiguration();
            return View(config);
        }
    }
}