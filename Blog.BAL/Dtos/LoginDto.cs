using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.BAL.Dtos
{
    public class LoginDto
    {
        [Length(6,50)]
        public string Email {  get; set; }
        [Length(6,100)]
        public string Password { get; set; }
    }
}