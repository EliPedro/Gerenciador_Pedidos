using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ClientesController : Controller
    {
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        } 
    }
}