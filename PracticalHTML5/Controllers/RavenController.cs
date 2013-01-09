using System;
using System.Web;
using System.Web.Mvc;
using Raven.Client;

namespace PracticalHTML5.Controllers
{
    public class RavenController : Controller
    {
        private IDocumentSession _db;
        public IDocumentSession DB
        {
            get
            {
                _db = _db ?? Global.DocumentStore.OpenSession();
                return _db;
            }
            internal set { _db = value; }
        }

        public virtual string UserName
        {
            get
            {
                var cookie = Request.Cookies["userName"];
                if (cookie != null)
                {
                    return cookie.Value;
                }
                return string.Empty;
            }
            set
            {
                Response.Cookies.Set(new HttpCookie("userName", value)
                {
                    Expires = DateTime.Now.AddYears(99)
                });
            }
        }


        protected override void EndExecute(IAsyncResult asyncResult)
        {
            base.EndExecute(asyncResult);

            if (_db != null)
            {
                _db.SaveChanges();
                _db.Dispose();
                _db = null;
            }
        }
    }
}