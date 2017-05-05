using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Final.Models.ViewModel
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}