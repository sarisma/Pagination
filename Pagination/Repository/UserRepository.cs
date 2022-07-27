using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Pagination.Repository
{
    public class UserRepository: IUserRepository
    {
        RepositoryDao dao;
        public UserRepository()
        {
            dao = new RepositoryDao();
        }

        public List<UserModel> GetUserList()
        {
            string sql = "exec sproc_user_detail @flag='list'";
            var dt = dao.ExecuteDataTable(sql);
            List<UserModel> list = new List<UserModel>();

            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    var data = new UserModel
                    {
                        FullName = item["full_name"].ToString(),
                        UserName = item["user_name"].ToString(),
                        MobileNUmber = item["user_mobile_no"].ToString(),
                        Email = item["user_email"].ToString()
                       
                    };
                    list.Add(data);

                }
            }
            return list;
        }
        //public List<UserModel> GetUserList(int pagenum)
        //{
        //    string sql = "exec sproc_user_detail @flag='paging'";
        //         sql += ",@PageNumber= " + pagenum  ;

        //    var dt = dao.ExecuteDataTable(sql);
        //    List<UserModel> list = new List<UserModel>();

        //    if (dt != null)
        //    {
        //        foreach (DataRow item in dt.Rows)
        //        {
        //            var data = new UserModel
        //            {
        //                FullName = item["full_name"].ToString(),
        //                UserName = item["user_name"].ToString(),
        //                MobileNUmber = item["user_mobile_no"].ToString(),
        //                Email = item["user_email"].ToString()

        //            };
        //            list.Add(data);
                    
        //        }
        //    }
            

        //    return list;
        //}    
        public List<UserModel> GetUserList(int startRowIndex, int maxRows)
        {
            string sql = "exec sproc_user_detail @flag='paging'";
            sql += ",@startRowIndex= " + startRowIndex;
            sql += ",@maximumRows= " + maxRows;

            var dt = dao.ExecuteDataTable(sql);
            List<UserModel> list = new List<UserModel>();

            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    var data = new UserModel
                    {
                        SN = item["RowRank"].ToString(),
                        FullName = item["full_name"].ToString(),
                        UserName = item["user_name"].ToString(),
                        MobileNUmber = item["user_mobile_no"].ToString(),
                        Email = item["user_email"].ToString()

                    };
                    list.Add(data);
                    
                }
            }
            

            return list;
        }
      
        public int TotalRecords()
        {
            string sql = "exec sproc_user_detail @flag='tot'";
            var dt = dao.ExecuteDataRow(sql);
            TotalRecords tot = new TotalRecords();
            if (dt != null)
            {
                tot.Total = (int)dt["TotalRecords"];
            }
            
            return tot.Total;
        }
    }
}