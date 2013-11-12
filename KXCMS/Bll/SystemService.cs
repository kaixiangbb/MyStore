using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKXCMS.Dal;
using PKXCMS.Model;

namespace PKXCMS.Bll
{
    public class SystemService
    {
        private static SystemService _instance;
        private SystemDal _dal;
        private static tblSystem _cacheConfig;

        /// <summary>
        /// 系统配置
        /// </summary>
        public tblSystem Config
        {
            get
            {
                if (_cacheConfig == null)
                    _cacheConfig = _dal.GetConfig();
                return _cacheConfig;
            }
        }

        private SystemService()
        {
            _dal = new SystemDal();
        }

        public static SystemService Instance()
        {
            if (_instance == null)
                _instance = new SystemService();
            return _instance;
        }

        #region 清除缓存的配置信息
        /// <summary>
        /// 清除缓存的配置信息
        /// </summary>
        public void ClearCache()
        {
            _cacheConfig = null;
        }
        #endregion
    }
}
