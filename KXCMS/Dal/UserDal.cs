using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKXCMS.Model;

namespace PKXCMS.Dal
{
    public class UserDal:BaseDal
    {
        #region GetSingle
        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="where">条件表达式</param>
        /// <returns></returns>
        public tblUser GetSingle(Func<tblUser,bool> where)
        {
            var entity = this.GetContext();
            return entity.tblUser.Where(where).SingleOrDefault();
        }
        #endregion
    }
}
