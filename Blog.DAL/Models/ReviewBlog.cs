using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Models
{
    public class ReviewBlog
    {
        [Key]
        public int Id { get; set; }
        public string ReviewBlogId { get; set; }
        public string UserId { get; set; }
        public string BlogId {  get; set; }
        public string ReviewID { get; set; }
    }
}

// 1 blog belongs to one User
// No Uses, For mapping Blog