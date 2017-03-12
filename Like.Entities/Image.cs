using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Entities
{
    public class Image : IEntityBase
    {
        public Image()
        {
            Preferences = new List<Preference>();
        }
        public int Id { get; set; }
        public string File { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
