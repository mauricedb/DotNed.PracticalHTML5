using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalHTML5.Models;

namespace PracticalHTML5.Controllers
{
    public class AdminController : RavenController
    {

        public ActionResult ClearAll()
        {
            var games = DB.Query<TicTacToe>();
            foreach (var game in games)
            {
                DB.Delete(game);
            }
            return Redirect("/")
                ;
        }

    }
}
