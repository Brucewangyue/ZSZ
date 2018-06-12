using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.Entity;
using Y.ZSZ.IBLL;
using Y.ZSZ.DAL;
namespace Y.ZSZ.BLL
{
    public class AdminUserBLL : IAdminUserBLL
    {
        public AdminUserDAL dal = new AdminUserDAL();
        public long ADD(string name, string phoneNum, string pwd, string email, long cityId, long[] roleIds)
        {
            return dal.ADD(name, phoneNum, pwd, email, cityId, roleIds);
        }

        public AdminUserDTO CheckUser(string phone, string pwd)
        {
            return dal.CheckUser(phone, pwd);
        }

        public bool Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public AdminUserDTO GetByPhoneNum(string phoneNum)
        {
            throw new NotImplementedException();
        }

        public List<AdminUserDTO> GetCityAdminUser(long cityId)
        {
            throw new NotImplementedException();
        }

        public AdminUserDTO GetModel(long Id)
        {
            throw new NotImplementedException();
        }

        public List<AdminUserDTO> GetModels()
        {
            return dal.GetModels();
        }

        public bool HasPermission(long UserId, long permisionId)
        {
            return dal.HasPermission(UserId, permisionId);
        }

        public bool HasPermission(long UserId, string permissionName)
        {
            return dal.HasPermission(UserId, permissionName);
        }

        public void Update(long Id, string name, string phoneNum, string pwd, string email, long cityId)
        {
            dal.Update(Id, name, phoneNum, pwd, email, cityId);
        }
    }
}
