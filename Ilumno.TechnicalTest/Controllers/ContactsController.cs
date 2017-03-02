using Ilumno.TechnicalTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ilumno.TechnicalTest.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new ContactFormViewModel();

            return View("ContactForm", viewModel);
        }
    }
}