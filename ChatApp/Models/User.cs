using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class User
    {
        public User()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage =" Name field is required.")]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Name { get; set; }

       
        public string Mail { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[A - Za - z])(?=.*\d)[A - Za - z\d]{8,}$")]
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
    }   

}
