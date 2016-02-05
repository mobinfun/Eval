using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dPajoohesh.EVS.Domain;
using Pajoohesh.EVS.Domain;

namespace Pajoohesh.EVS.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Mehvar> mehvaRepository = null;
        private IRepository<CodeType> codeTypeRepository = null;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}