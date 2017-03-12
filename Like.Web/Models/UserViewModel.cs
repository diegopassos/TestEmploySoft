using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Like.Web.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Preferences = new List<PreferenceViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PreferenceViewModel> Preferences { get; set; }
    }
}