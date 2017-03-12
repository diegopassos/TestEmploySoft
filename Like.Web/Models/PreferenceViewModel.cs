using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Like.Web.Models
{
    public class PreferenceViewModel
    {
        public PreferenceViewModel()
        {
            Image = new ImageViewModel();
        }
        public int Id { get; set; }
        public bool Like { get; set; }
        public int ImageId { get; set; }
        public int UserId { get; set; }
        public DateTime DateLike { get; set; }
        public ImageViewModel Image { get; set; }
    }
}