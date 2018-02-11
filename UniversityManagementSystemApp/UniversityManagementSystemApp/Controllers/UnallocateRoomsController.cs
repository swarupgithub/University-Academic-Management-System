using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystemApp.Manager;

namespace UniversityManagementSystemApp.Controllers
{
    public class UnallocateRoomsController : Controller
    {
        private UnallocateRoomsManager _unallocateRoomsManager;

        public UnallocateRoomsController()
        {
            _unallocateRoomsManager = new UnallocateRoomsManager();
        }
        //
        // GET: /UnallocateRooms/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string unallocate)
        {
            ViewBag.message = _unallocateRoomsManager.UnAssignCousesManager();
            return View();
        }
	}
}