using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PKXCMS.Common
{
    public class RegCodeHelper
    {
        public static void Build()
        {
            var fileName = System.AppDomain.CurrentDomain.BaseDirectory + "code.gif";
            HttpContext.Current.Session["loginregcode"] = Kaixiang.RegCodeBuilder.RegCode.Build(4, 65, 18, fileName);
        }

        /// <summary>
        /// 获取Session里的验证码
        /// </summary>
        /// <returns></returns>
        public static string GetSessionCode()
        {
            return HttpContext.Current.Session["loginregcode"].ToString();
        }
    }
}
