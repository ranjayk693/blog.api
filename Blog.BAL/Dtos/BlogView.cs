using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Dtos
{
    public class BlogView
    {
        public string? Id { get; set; }
        [Length(1,100)]
        public string Title { get; set; }
        [Length(2,10000)]
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
