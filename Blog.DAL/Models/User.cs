using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserID {  get; set; }
        public string? ImageURl {  get; set; }
        public string FirstName { get; set; }
        public string? MiddleName {  get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public bool IsActive {  get; set; }
        public bool IsArchieve {  get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        // Refrence to other table
        public string RoleID { get; set; }
    }
}
