using CommerceListMVC.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace CommerceListMVC.Controllers
{
  
    public class BaseController : Controller
    {
      protected void SetValueToSession<T>(string key, T value)
        {
            HttpContext.Session.SetObject<T>(key, value);
        }
        protected T GetValueFromSession<T>(string key)
        {
            return HttpContext.Session.GetObject<T>(key);
        }
        protected bool IsExistInSession(string key)
        {
            return HttpContext.Session.Keys.Contains(key);
        }
        protected void ClearSession(string key = null)
        {
            if(string.IsNullOrEmpty(key))
            {
                HttpContext.Session.Clear();
            }
            else { HttpContext.Session.Remove(key); }
        }
       
    }
}
