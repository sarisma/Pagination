using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Pagination.Repository
{
    public interface IUserRepository
    {
        List<UserModel> GetUserList();
       // List<UserModel> GetUserList(int pagenum);
        List<UserModel> GetUserList(int startRowIndex, int maxRows);
        int TotalRecords();
    }
}