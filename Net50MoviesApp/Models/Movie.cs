﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net50MoviesApp.Models
{
    public class Movie
    {
        
        public int MovieId { get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
        public string  Director{ get; set; }
        public string Year { get; set; }
        public string ImageUrl { get; set; }
        public string[] Cast{ get; set; }
    }
}
