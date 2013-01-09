using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalHTML5.Indexes;
using PracticalHTML5.Models;
using PracticalHTML5.ViewModels;

namespace PracticalHTML5.Controllers
{
    public class StatsController : RavenController
    {

        //private const string _viewName = "Index";
        private const string _viewName = "StoredIndex";

        public ActionResult Index()
        {
            return View(_viewName);
        }

        public ActionResult Data()
        {
            Response.Cache.SetMaxAge(TimeSpan.Zero);
            var query = DB.Query<PlayerStatisticsIndexCreationTask.Result, PlayerStatisticsIndexCreationTask>();

            return Json(query.ToList(), JsonRequestBehavior.AllowGet);
        }


    }
}
