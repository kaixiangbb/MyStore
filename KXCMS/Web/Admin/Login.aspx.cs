using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PKXCMS.Bll;
using PKXCMS.Model;
using PKXCMS.Common;
using System.Web.Security;

namespace Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        public bool IsRegCode = SystemService.Instance().Config.IsRegCodeByLogin == 0 ? false : true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegCodeHelper.Build();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = null;
                tblUser loginUser;
                this.lblError.InnerText = string.Empty;
                var userName = this.userName.Value.Trim();
                var pwd = this.pwd.Value.Trim();
                if (IsRegCode)
                {
                    var regCode = this.regCode.Value.Trim();
                    var sessionCode = RegCodeHelper.GetSessionCode();
                    if (string.IsNullOrEmpty(regCode) || sessionCode != regCode)
                    {
                        this.lblError.InnerText = "验证码错误!";
                        return;
                    }
                    else
                    {
                        var result = UserService.Instance().UserCheck(userName, pwd, out msg,out loginUser);
                        if (result)//登录成功
                        {
                            if (loginUser.Role == 1)
                            {
                                SetFormsAuthentication(loginUser.UserName, "Admin");
                                Response.Redirect("Default.aspx");
                            }
                            else
                            {
                                this.lblError.InnerText = "无管理员权限";
                                return;
                            }
                        }
                        else
                            this.lblError.InnerText = msg;
                    }
                }
                else 
                { 
                    var result = UserService.Instance().UserCheck(userName, pwd, out msg,out loginUser);
                    if (result)//登录成功
                    {
                        if (loginUser.Role == 1)
                        {
                            SetFormsAuthentication(loginUser.UserName, "Admin");
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            this.lblError.InnerText = "无管理员权限";
                            return;
                        }
                    }
                    else
                        this.lblError.InnerText = msg;
                }
            }
            catch (Exception err)
            {
                this.lblError.InnerText = err.Message;
            }
        }

        private void SetFormsAuthentication(string userName,string Role)
        {
            FormsAuthentication.Initialize();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddDays(1), false, Role);
            var hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            Response.Cookies.Add(cookie);
        }
    }
}