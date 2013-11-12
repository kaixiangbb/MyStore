using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKXCMS.Model;

namespace PKXCMS.Dal
{
    public class SystemDal:BaseDal
    {
        #region GetConfig
        /// <summary>
        /// 获取系统配置信息
        /// </summary>
        /// <returns></returns>
        public tblSystem GetConfig()
        {
            return this.GetContext().tblSystem.Single();
        }
        #endregion
    }
}
