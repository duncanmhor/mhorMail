using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MhorMail.Services.Abstract;

namespace MhorMail.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IAccountService _accountService;

        public HomeController(IMailService mailService, IAccountService accountService)
        {
            _mailService = mailService;
            _accountService = accountService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}