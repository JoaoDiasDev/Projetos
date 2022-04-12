using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoaoDiasBlog.Entities;

namespace JoaoDiasBlog.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            user = new User();
            Success = false;
            Message = string.Empty;
        }

        public User user { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    
}
