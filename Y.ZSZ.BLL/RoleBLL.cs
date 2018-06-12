using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DAL;
using Y.ZSZ.DTO;
using Y.ZSZ.IBLL;

namespace Y.ZSZ.BLL
{
    public class RoleBLL : IRoleBLL
    {
        private RoleDAL dal = new RoleDAL();
        public long Add(string name, string description, long[] permissionIds)
        {
            return dal.Add(name, description, permissionIds);
        }

        public void Delete(long Id)
        {
             dal.Delete(Id);
        }

        public void DeleteMany(long[] ids)
        {
            dal.DeleteMany(ids);
        }

        public List<RoleDTO> GetAll()
        {
            return new RoleDAL().GetAll();
        }

        public RoleDTO GetById(long Id)
        {
            return dal.GetById(Id);
        }

        public void Update(long Id, string name,string description,long[] permissionIds)
        {
            dal.Update(Id, name, description, permissionIds);
        }
    }
}
