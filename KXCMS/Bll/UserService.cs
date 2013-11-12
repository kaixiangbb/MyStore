using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKXCMS.Model;
using PKXCMS.Dal;

namespace PKXCMS.Bll
{
    public class UserService
    {
        private static UserService _instance;
        private UserDal _dal;

        private UserService()
        {
            _dal = new UserDal();
        }

        public static UserService Instance()
        {
            if (_instance == null)
                _instance = new UserService();
            return _instance;
        }

        #region UserCheck
        /// <summary>
        /// 验证登录用户，成功返回True，反之
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="msg">登录失败错误信息</param>
        /// <returns></returns>
        public bool UserCheck(string userName, string pwd, out string msg, out tblUser loginUser)
        {
            try
            {
                var user = _dal.GetSingle(m => m.UserName == userName);
                if (user == null)
                {
                    msg = "用户名不正确!";
                    loginUser = null;
                    return false;
                }
                if (user.Password == pwd)
                {
                    if (user.UserState == 1)
                    {
                        msg = "用户已经被禁用,请联系管理员!";
                        loginUser = null;
                        return false;
                    }
                    msg = null;
                    loginUser = user;
                    return true;
                }
                msg = "密码错误!";
                loginUser = null;
                return false;
            }
            catch (Exception err)
            {
                msg = err.Message;
                loginUser = null;
                return false;
            }
        }
        #endregion
    }
}
