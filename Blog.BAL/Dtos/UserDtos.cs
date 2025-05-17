using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BAL.Dtos
{
    public class UserDtos
    {
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string UserEmail { get; set; }
        [Length(6,50)]
        public string Password { get; set; }
        public string? ImageURl { get; set; }
        [Length(10,10)]
        public string? PhoneNumber { get; set; }
        [Length(3,50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string? MiddleName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }

    }
}
