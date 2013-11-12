using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VTemplate;

namespace Web
{
    public partial class Index : System.Web.UI.Page
    {
        private string _templateFile = AppDomain.CurrentDomain.BaseDirectory + "Template/_index.htm";
        protected void Page_Load(object sender, EventArgs e)
        {
            VTemplate.Engine.TemplateDocument document = new VTemplate.Engine.TemplateDocument(_templateFile, System.Text.Encoding.UTF8);
            var user=new User(){ Name="普开祥" };
            document.SetValue("user", user);
            document.Render(Response.Output);
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}