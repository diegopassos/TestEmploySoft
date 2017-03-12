using Like.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Data.Configurations
{
    public class ErrorConfiguration : EntityBaseConfiguration<Error>
    {
        public ErrorConfiguration()
        {
            Property(g => g.Message).IsRequired().HasMaxLength(200);
            Property(g => g.StackTrace).IsRequired().IsMaxLength();
            Property(g => g.DateCreated).IsRequired();
        }
    }
}
