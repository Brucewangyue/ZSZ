using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;

namespace Y.ZSZ.IBLL
{
    public interface IAdminUserBLL : IAutofacBLL
    {
        /// <summary>
        /// 检查用户
        /// </summary>
        /// <returns></returns>
        AdminUserDTO CheckUser(string phone, string pwd);
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        long ADD(string name, string phoneNum, string pwd, string email, long cityId,long[] roleId);
        /// <summary>
        /// 修改用户---------修改有问题
        /// </summary>
        /// <returns></returns>
        void Update(long Id, string name, string PhoneNum, string pwd, string email, long cityId);
        /// <summary>
        /// 获取所有管理员
        /// </summary>
        /// <returns></returns>
        List<AdminUserDTO> GetModels();
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        AdminUserDTO GetModel(long Id);
        /// <summary>
        /// 根据手机号获取管理员
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        AdminUserDTO GetByPhoneNum(string phoneNum);
        /// <summary>
        /// 获取某一个城市de管理员
        /// </summary>
        /// <returns></returns>
        List<AdminUserDTO> GetCityAdminUser(long cityId);
        /// <summary>
        /// 是否有该名称权限----有问题
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="permissionName">权限名称</param>
        /// <returns></returns>
        bool HasPermission(long UserId, string permissionName);
        /// <summary>
        /// 是否有该Id权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="permisionId"></param>
        /// <returns></returns>
        bool HasPermission(long UserId, long permisionId);
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(long Id);
    }
}
