using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;

namespace Y.ZSZ.IBLL
{
    public interface IPermissionBLL:IAutofacBLL
    {
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <returns></returns>
        List<PermissionDTO> GetAll();
        /// <summary>
        /// 新增权限
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        long Add(string name, string description);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionDTO GetById(long id);
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        void Update(long id, string name, string description);
    }
}
