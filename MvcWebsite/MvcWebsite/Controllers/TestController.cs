using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcWebsiteSystem.Entities;
using MvcWebsite.Models;
using MvcWebsiteSystem.BLL;

namespace MvcWebsite.Controllers
{
    public class TestController : Controller
    {
        private RegionController rc = new RegionController();

        // GET: Test
        public ActionResult Index()
        {
            //return View(regionModel.Region_List());
            return View(rc.Region_List());
        }

        public ActionResult Edit(int? id)
        {
            if (id.Equals(null))
            {
                return View();
            }
            else
            {
                int regionIdentity = id ?? default(int);
                return View(rc.Region_Get(regionIdentity));
            }

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "RegionID, RegionDescription")] Region region)
        {
            if (ModelState.IsValid)
            {
                rc.Update_Region(region);
                return RedirectToAction("Index");
            }
                
            return View();
        }

    }
}