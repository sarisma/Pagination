using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagination.Business
{
    public interface IUserBusiness
    {
        List<UserModel> GetUserList();
        List<UserModel> GetUserList(int pagenum);
    }
}