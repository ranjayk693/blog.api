using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Models
{
    public class Roles
    {
        [Key]
        public int ID { get; set; }
        public string RoleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level {  get; set; }
        public bool IsActive {  get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
