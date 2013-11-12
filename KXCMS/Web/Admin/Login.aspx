<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理员登录</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body style=" background-color:#fff; ">
    <form id="form1" runat="server">
    <div>
       <fieldset>
          <legend>登录</legend>
          <p>
             <span> <strong>用户名：</strong> </span>
             <input id="userName" name="userName" type="text" runat="server" />
          </p>
          <p>
             <span> <strong>密&nbsp;&nbsp;&nbsp;&nbsp;码：</strong> </span>
             <input id="pwd" name="pwd" type="text" runat="server" />
          </p>
          <% if (IsRegCode) { %>
          <p>
              <span> <strong>验证码：</strong> </span>
              <input id="regCode" name="regCode" type="text" runat="server" />
              <img title="刷新" alt="验证码" style="cursor:pointer" src="/code.gif" />
          </p>
          <% } %>
          <p>
              <asp:Button ID="btnLogin" runat="server" Text="登录" onclick="btnLogin_Click" />
          </p>
          <p>
            <span class="failureNotification" runat="server" id="lblError"></span>
          </p>
       </fieldset>
    </div>
    </form>
</body>
</html>
