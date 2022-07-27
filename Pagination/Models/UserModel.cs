using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pagination.Models
{
    public class UserModel
    {
        public string SN { get; set; }
        public string UserName { get; set; }
        [Display(Name = "Full Name ")]
        public string FullName { get; set; }
        [Display(Name = "Mobile Number ")]
        public string MobileNUmber { get; set; }

        public string Email { get; set; }
    }
    public class TotalRecords
    {
        public int Total { get; set; }
    }
}