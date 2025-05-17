using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId {  get; set; }
        public string UserID {  get; set; }
        public bool IsActive {  get; set; }
        public DateTime DateCreated {  get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
