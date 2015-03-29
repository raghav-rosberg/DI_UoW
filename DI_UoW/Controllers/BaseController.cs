using System.Web.Mvc;

namespace DI_UoW.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
        }
    }
}
