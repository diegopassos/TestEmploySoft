using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Like.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Data.Configurations
{
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}
