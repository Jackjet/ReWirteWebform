using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ReWirteWebForm
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //目标：实现index-1.aspx→index.aspx?id=1

            //获取用户访问的虚拟路径。具体形式如：~/index-1.aspx
            string url = Context.Request.AppRelativeCurrentExecutionFilePath;

            //通过正则匹配
            Regex regex = new Regex(@"~/index-(\d+?).aspx");
            var matches =regex.Matches(url);

            if (matches.Count > 0)
            {
                //替换处理为原地址。
                string relPath = regex.Replace(url, "~/index.aspx?id=$1");

                //交由原地址处理显示出来
                Context.RewritePath(relPath);

            }

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}