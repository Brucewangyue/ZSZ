using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.IBLL;
using Y.ZSZ.DAL;
namespace Y.ZSZ.BLL
{
    public class DictionaryBLL : IDictionaryBLL
    {
        public DictionaryDAL dal = new DictionaryDAL();
        public List<DictionaryDTO> GetByTypes(params string[] types)
        {
            return dal.GetByTypes(types);
        }
    }
}
