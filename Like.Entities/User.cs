using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Like.Entities
{
    public class User : IEntityBase
    {
        public User()
        {
            Preferences = new List<Preference>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
