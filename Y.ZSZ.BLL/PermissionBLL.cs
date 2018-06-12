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
    public class PermissionBLL : IPermissionBLL
    {
        public PermissionDAL dal = new PermissionDAL();

        public long Add(string name, string description)
        {
            return dal.Add(name, description);
        }

        public void Delete(long id)
        {
            dal.Delete(id);
        }

        public List<PermissionDTO> GetAll()
        {
            return dal.GetAll();
        }

        public PermissionDTO GetById(long id)
        {
            return dal.GetById(id);
        }

        public void Update(long id, string name, string description)
        {
             dal.Update(id,name, description);
        }
    }
}
