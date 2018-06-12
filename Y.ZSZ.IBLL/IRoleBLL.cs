using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;

namespace Y.ZSZ.IBLL
{
    public interface IRoleBLL : IAutofacBLL
    {
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        List<RoleDTO> GetAll();
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        RoleDTO GetById(long Id);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        void Update(long Id, string name,string description,long[] permissionIds);
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        long Add(string name,string description,long[] permissionIds);
        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="Id"></param>
        void Delete(long Id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeleteMany(long[] ids);
    }
}
