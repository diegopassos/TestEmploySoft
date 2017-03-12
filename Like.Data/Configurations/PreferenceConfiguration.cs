using Like.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Data.Configurations
{
    public class PreferenceConfiguration : EntityBaseConfiguration<Preference>
    {
        public PreferenceConfiguration()
        {
            Property(g => g.Like).IsRequired();
            Property(g => g.DateLike).IsRequired();
        }        
    }
}
