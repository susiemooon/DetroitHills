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

        [Required(ErrorMessage ="You should write your username")]
        public string username { get; set; }

        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="You should write a password")]
        public string password { get; set; }
    }
}