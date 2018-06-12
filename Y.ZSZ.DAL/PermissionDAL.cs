using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.Entity;

namespace Y.ZSZ.DAL
{
    public class PermissionDAL
    {
        public List<PermissionDTO> GetAll()
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<PermissionEntity> dal = new CommonDAL<PermissionEntity>(context);
                return dal.GetModels().ToList().Select(s => ToDTO(s)).ToList();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(long Id)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<PermissionEntity> dal = new CommonDAL<PermissionEntity>(context);
                PermissionEntity permission = dal.GetModel(Id);
                if (permission == null)
                {
                    throw new ArgumentException("找不到Id为：" + Id + "的数据");
                }
                permission.IsDelete = true;
                permission.DeleteDate = DateTime.Now;
                //context.Entry(permission).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(long id, string name, string description)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<PermissionEntity> dal = new CommonDAL<PermissionEntity>(context);
                PermissionEntity permission = dal.GetModel(id);
                if (permission==null)
                {
                    throw new ArgumentException("不存在id为【" + id + "】的记录");
                }

                if (dal.GetModels().Any(s => s.Name == name && s.Name!= permission.Name))
                {
                    throw new ArgumentException("已经存在【" + name + "】权限名称");
                }

                permission.Name = name;
                permission.Description = description;
                context.SaveChanges();
            }
        }

        public PermissionDTO GetById(long id)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<PermissionEntity> dal = new CommonDAL<PermissionEntity>(context);
                PermissionEntity permission = dal.GetModel(id);
                return ToDTO(permission);
            }
        }

        public long Add(string name, string description)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                PermissionEntity permission = new PermissionEntity
                {
                    Description = description,
                    Name = name
                };

                context.Permissions.Add(permission);
                context.SaveChanges();
                return permission.Id;
            }
        }

        private PermissionDTO ToDTO(PermissionEntity s)
        {
            if (s == null) return null;
            return new PermissionDTO()
            {
                Id = s.Id,
                CreateDate = s.CreateDate,
                Description = s.Description,
                Name = s.Name
            };
        }
    }
}
