﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Dtos
{
    public class BlogDetailView
    {
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
