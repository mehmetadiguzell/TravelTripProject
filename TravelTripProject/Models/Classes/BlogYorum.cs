using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class BlogYorum
    {
        public IEnumerable<Blog> WmBlog { get; set; }
        public IEnumerable<Yorumlar> WmYorum { get; set; }
        public IEnumerable<Blog> SonBloglar { get; set; }
    }
}