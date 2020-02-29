using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AJ.IssueTracker.Services
{
    public static class HttpHelper
    {
        public static string ToQueryString<T>(T model)
        {
            string result = string.Empty;
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }
            var properties = model.GetType().GetProperties().Where(m => m.GetValue(model) != null);
            result = string.Join("&", properties.Select(m =>
               string.Format("{0}={1}", HttpUtility.UrlEncode(m.Name), HttpUtility.UrlEncode(m.GetValue(model).ToString()))));
            return result;
        }
    }
}
