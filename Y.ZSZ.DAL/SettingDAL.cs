using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.Entity;

namespace Y.ZSZ.DAL
{
    public class SettingDAL//:BaseDAL<SettingEntity>
    {
        /// <summary>
        /// 添加系统设置，并且返回主键
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long ADD(string key, string value,string description)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                bool isExist = context.Settings.Any(s => s.Key == key);
                if (isExist)
                {
                    throw new ArgumentException("已经存在该主键");
                }
                SettingEntity entity = new SettingEntity
                {
                     Key= key,
                     Value=value,
                     Description= description
                };
                context.Settings.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }
    }
}
