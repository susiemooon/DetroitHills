using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "NameRequired")]
        public string username { get; set; }

        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "PasswordRequired")]
        public string password { get; set; }
    }
}