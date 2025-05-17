using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string ReviewId { get; set; }
        public string UserId { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        // Refrence to other table
        public string BlogId {  get; set; }  // It is optional as ReviewBlog keep record of Review and blog
    }
}
