using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.IBLL;
using Y.ZSZ.DAL;
using Y.ZSZ.DTO;
namespace Y.ZSZ.BLL
{
    public class SettingBLL : ISettingBLL
    {
        public long ADD(string key, string value,string description)
        {
            //return 12;
            return new SettingDAL().ADD(key, value, description);
        }
    }
}
