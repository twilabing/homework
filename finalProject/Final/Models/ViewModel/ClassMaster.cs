using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models.ViewModel
{
    public class ClassMaster
    {
        [Key]
        public int classID { get; set; }

        [Display(Name = "Class Name")]
        public string className { get; set; }

        [Display(Name = "Class Description")]
        public string classDescription { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal classPrice { get; set; }

        [Display(Name = "Sessions")]
        public int classSessions { get; set; }
    }

    public class UserClasses
    {
        [Key, Column(Order = 1)]
        public int userID { get; set; }


        [Key, Column(Order = 2)]
        public int classID { get; set; }


    }


}