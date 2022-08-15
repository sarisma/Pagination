using Pagination.Models;
using Pagination.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Pagination.Business
{
    public class UserBusiness: IUserBusiness
    {
        UserRepository _repo;
        public UserBusiness()
        {
            _repo = new UserRepository();
        }
        public List<UserModel> GetUserList()
        {
            return _repo.GetUserList();
        }
        public List<UserModel> GetUserListP(int pagenum,int maxrows)
        {
            return _repo.GetUserListP(pagenum,maxrows);
        }
        public List<UserModel> GetUserList(int startRowIndex, int maxRows)
        {
            return _repo.GetUserList(startRowIndex, maxRows);
        }
        public int TotalRecords()
        {
            return _repo.TotalRecords();
        }
    
    }
}