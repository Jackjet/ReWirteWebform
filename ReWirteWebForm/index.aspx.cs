using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReWirteWebForm
{
    public partial class index : System.Web.UI.Page
    {
        protected string MyContent { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取传过来的id
            string id = Context.Request["id"];

            if (string.IsNullOrEmpty(id))
            {
                //如果没有传入id的参数，直接返回。
                return;
            }
            //id转换为int类型
            int result = 0;
            bool isTrue = int.TryParse(id, out result);
            if (!isTrue)
            {
                //如果不是int类型的值直接返回。
                return;
            }

            //根据id到数据库获取数据，这里我们用Dictionary模拟一下
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "我是第一个数据");
            dict.Add(2, "我是第二个数据");

            MyContent = dict[result];

        }
    }
}