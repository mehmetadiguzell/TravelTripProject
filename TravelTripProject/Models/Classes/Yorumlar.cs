﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Classes
{
    public class Yorumlar
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string Yorum { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}