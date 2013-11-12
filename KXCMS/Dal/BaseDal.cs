using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using PKXCMS.Model;

namespace PKXCMS.Dal
{
    public abstract class BaseDal
    {
        protected PKXCMSEntities GetContext()
        {
            return new PKXCMSEntities();
        }
    }
}
