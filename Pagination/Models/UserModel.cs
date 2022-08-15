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
        public string MobileNumber { get; set; }

        public string Email { get; set; }
    }
    public class TotalRecords
    {
        public int Total { get; set; }
    }
    public class JqueryDatatableParam
    {
        public string sEcho { get; set; }
        public string sSearch { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public int iColumns { get; set; }
        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
    }
}