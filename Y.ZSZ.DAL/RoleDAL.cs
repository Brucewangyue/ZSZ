using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.DTO;
using Y.ZSZ.Entity;
using System.Data.Entity;

namespace Y.ZSZ.DAL
{
    public class RoleDAL
    {
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<RoleDTO> GetAll()
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<RoleEntity> dal = new CommonDAL<RoleEntity>(context);
                return dal.GetModels().Include(s => s.AdminUsers).Include(s => s.Permissions).ToList().Select(s => ToDTO(s)).ToList();
            }
        }

        private RoleDTO ToDTO(RoleEntity s)
        {
            if (s == null) return null;

            return new RoleDTO
            {
                CreateDate = s.CreateDate,
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                AdminsUserNames = string.Join(",", s.AdminUsers.Select(ss => ss.Name)),
                PermissionIds = s.Permissions.Select(p => p.Id).ToArray()
            };
        }

        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RoleDTO GetById(long Id)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<RoleEntity> dal = new CommonDAL<RoleEntity>(context);
                var entity = dal.GetModels().Include(s => s.Permissions).AsNoTracking().FirstOrDefault(s => s.Id == Id);
                if (entity == null)
                {
                    return null;
                }

                return ToDTO(entity);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        public void Update(long Id, string name, string description, long[] permissionIds)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<RoleEntity> dal = new CommonDAL<RoleEntity>(context);
                //CommonDAL<PermissionEntity> permisionDal = new CommonDAL<PermissionEntity>(context);
                var entity = dal.GetModels().Include(s => s.Permissions).FirstOrDefault(s => s.Id == Id);
                if (entity == null) throw new ArgumentException("没有Id为【" + Id + "】的数据");

                //删除
                //if (entity.Permissions!=null)
                //{
                //    foreach (var permission in entity.Permissions)
                //    {
                //        //context.Permissions.Remove(permission);
                //        context.Entry(permission).State = EntityState.Deleted;
                //    }
                //}
                entity.Permissions.Clear();

                if (permissionIds != null)
                {
                    //添加
                    foreach (var permission in context.Permissions.Where(s => permissionIds.Contains(s.Id)))
                    {
                        entity.Permissions.Add(permission);
                    }
                }

                entity.Description = description;
                entity.Name = name;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public long Add(string name, string description, long[] permissionIds)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<RoleEntity> dal = new CommonDAL<RoleEntity>(context);
                //如何删除中间表的数据
                if (dal.Any(s => s.Name == name)) throw new ArgumentException("已经存在【" + name + "】权限");

                var entity = new RoleEntity() { Name = name };

                if (permissionIds != null)
                {
                    CommonDAL<PermissionEntity> permissionDal = new CommonDAL<PermissionEntity>(context);
                    var permissions = permissionDal.GetModels(s => permissionIds.Contains(s.Id));
                    if (permissions.Count() > 0)
                    {
                        foreach (var permission in permissions)
                        {
                            entity.Permissions.Add(permission);
                        }
                    }
                }

                entity.Description = description;
                entity.Name = name;
                context.Roles.Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(long Id)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                var entity = new RoleEntity() { Id = Id };
                CommonDAL<RoleEntity> dal = new CommonDAL<RoleEntity>(context);
                dal.MarkDelete(Id);
                //context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteMany(long[] ids)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                //using (TransactionScope transaction = new TransactionScope())
                //{

                //}
                CommonDAL<RoleEntity> dal = new CommonDAL<RoleEntity>(context);
                foreach (var roleId in ids)
                {
                    dal.MarkDelete(roleId);
                }

                context.SaveChanges();
            }
        }
    }
}
