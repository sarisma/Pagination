using Pagination.Models;
using Pagination.Repository;
using System;
using System.Collections.Generic;
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
        } public List<UserModel> GetUserList(int pagenum)
        {
            return _repo.GetUserList(pagenum);
        }
    }
}