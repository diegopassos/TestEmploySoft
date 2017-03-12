using Like.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Data.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(50);
            HasMany(s => s.Preferences).WithRequired(r => r.User).HasForeignKey(r => r.UserId);
        }
    }
}
