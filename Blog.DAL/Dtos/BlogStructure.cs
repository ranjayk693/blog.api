﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Dtos
{
    public class BlogStructure
    {
        public string Section {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL {  get; set; }
    }
}
