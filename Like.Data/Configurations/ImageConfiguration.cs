using Like.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Data.Configurations
{
    public class ImageConfiguration : EntityBaseConfiguration<Image>
    {
        public ImageConfiguration()
        {
            Property(g => g.File).IsRequired().IsMaxLength();
            Property(g => g.Description).IsRequired().HasMaxLength(100);
            HasMany(s => s.Preferences).WithRequired(r => r.Image).HasForeignKey(r => r.ImageId);
        }
    }
}
