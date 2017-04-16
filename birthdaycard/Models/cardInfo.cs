using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace birthdaycard.Models
{
    public class cardInfo
    {
        [Required(ErrorMessage = "Please whom this card should be sent to")]
        public string to { get; set; }

        [Required(ErrorMessage = "Please who this card is from")]
        public string from { get; set; }

        [Required(ErrorMessage = "Please specify message to include")]
        public string message { get; set; }
    }
}