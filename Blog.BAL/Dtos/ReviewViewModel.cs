using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Dtos
{
    public class ReviewViewModel
    {
        public string Author {  get; set; }
        public List<ReviewsView> ReviewsViews { get; set; }
    }

    public class ReviewsView
    {
        public string ReviewId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

