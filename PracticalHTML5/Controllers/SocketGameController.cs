using System.Web.Mvc;

namespace PracticalHTML5.Controllers
{
    public class SocketGameController : Controller
    {
        //private const string _viewName = "Play";
        private const string _viewName = "DragDropPlay";

        public ActionResult Play(int id)
        {
            return View(_viewName);
        }

    }
}
