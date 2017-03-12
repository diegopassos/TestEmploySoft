using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        LikeContext dbContext;

        public LikeContext Init()
        {
            return dbContext ?? (dbContext = new LikeContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
