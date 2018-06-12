using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.Entity;
using Y.ZSZ.Core;
using Y.ZSZ.DTO;
using System.Data.Entity;
namespace Y.ZSZ.DAL
{
    public class AdminUserDAL
    {
        /// <summary>
        /// 检查用户
        /// </summary>
        /// <returns></returns>
        public AdminUserDTO CheckUser(string phone, string pwd)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> dal = new CommonDAL<AdminUserEntity>(context);
                AdminUserEntity adminUser = dal.GetSingle(s => s.PhoneNum == phone);
                if (adminUser == null) return null;
                return adminUser.PasswordHash == CommomHelper.CalcMD5(pwd + adminUser.PasswordSalt)?ToDTO(adminUser):null;
            }
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        public long ADD(string name, string phoneNum, string pwd, string email, long cityId,long[] roleIds)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<CityEntity> cityDal = new CommonDAL<CityEntity>(context);
                CommonDAL<RoleEntity> roleDal = new CommonDAL<RoleEntity>(context);
                //城市
                CityEntity city = cityDal.GetModel(cityId);
                if (city == null)
                {
                    throw new ArgumentException("城市id:" + cityId + "查无数据");
                }
               

                CommonDAL<AdminUserEntity> adminDal = new CommonDAL<AdminUserEntity>(context);
                if (context.AdminUsers.Any(s => s.PhoneNum == phoneNum))
                {
                    throw new ArgumentException("该手机号：" + phoneNum + "已经被注册");
                }

                string salt = CommomHelper.CreateVerifyCode(5);
                string pwdHash = CommomHelper.CalcMD5(pwd + salt);
                AdminUserEntity user = new AdminUserEntity
                {
                    PhoneNum = phoneNum,
                    Name = name,
                    Email = email,
                    City = city,
                    PasswordHash = pwdHash,
                    PasswordSalt = salt
                };

                //角色
                if (roleIds != null)
                {
                    foreach (var roleId in roleIds)
                    {
                        user.Roles.Add(roleDal.GetModel(roleId));
                    }
                }

                context.AdminUsers.Add(user);
                context.SaveChanges();
                return user.Id;
            }
        }
        /// <summary>
        /// 修改用户---------修改有问题
        /// </summary>
        /// <returns></returns>
        public void Update(long Id, string name, string PhoneNum, string pwd, string email, long cityId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> dal = new CommonDAL<AdminUserEntity>(context);
                AdminUserEntity user = dal.GetModel(Id);
                if (user == null)
                {
                    throw new ArgumentException("管理员id：" + Id + "查无数据");
                }
                user.PhoneNum = PhoneNum;
                user.Name = name;
                user.Email = email;
                user.CityId = cityId;
                user.PasswordHash = CommomHelper.CalcMD5(pwd + user.PasswordSalt);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 获取所有管理员
        /// </summary>
        /// <returns></returns>
        public List<AdminUserDTO> GetModels()
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> adminDal = new CommonDAL<AdminUserEntity>(context);
                return adminDal.GetModels()
                    .Include(s => s.City).Include(s => s.Roles).AsNoTracking().ToList()//注意不要延迟加载
                    .Select(s => ToDTO(s)).ToList();
            }
        }
        /// <summary>
        /// 实体转DTO
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        private AdminUserDTO ToDTO(AdminUserEntity userEntity)
        {
            if (userEntity == null) return null;
            AdminUserDTO dto = new AdminUserDTO
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                CityId = userEntity.CityId,
                CityName = userEntity.City.Name,
                Email = userEntity.Email,
                CreateDate = userEntity.CreateDate,
                PhoneNum = userEntity.PhoneNum,
                LastLoginErrorDateTime = userEntity.LastLoginErrorDateTime,
                LoginErrorTimes = userEntity.LoginErrorTimes,
                RoleNames = string.Join(",", userEntity.Roles.Select(s => s.Name))
            };
            return dto;
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public AdminUserDTO GetModel(long Id)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> adminDal = new CommonDAL<AdminUserEntity>(context);
                AdminUserEntity adminUser = adminDal.GetModels()
                    .Include(s => s.City).AsNoTracking()
                    .SingleOrDefault(s => s.Id == Id); //adminDal.GetModel(Id);
                return ToDTO(adminUser);
            }
        }
        /// <summary>
        /// 根据手机号获取管理员
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <returns></returns>
        public AdminUserDTO GetByPhoneNum(string phoneNum)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> adminDal = new CommonDAL<AdminUserEntity>(context);
                var adminResult = adminDal.GetModels().Include(s => s.City).AsNoTracking()
                    .Where(s => s.PhoneNum == phoneNum);
                if (adminResult.Count() > 1)//手机号是唯一的要做好异常提醒处理
                {
                    throw new ApplicationException("该手机号：" + phoneNum + "存在多条记录");
                }
                else if (adminResult.Count() == 1)
                {
                    return ToDTO(adminResult.Single());
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 获取某一个城市de管理员
        /// </summary>
        /// <returns></returns>
        public List<AdminUserDTO> GetCityAdminUser(long cityId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> adminDal = new CommonDAL<AdminUserEntity>(context);
                return adminDal.GetModels(s => s.CityId == cityId)
                    .Include(s => s.City).AsNoTracking()
                    .Select(s => ToDTO(s)).ToList();
            }
        }
        /// <summary>
        /// 是否有该名称权限----有问题
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="permissionName">权限名称</param>
        /// <returns></returns>
        public bool HasPermission(long UserId, string permissionName)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> adminDal = new CommonDAL<AdminUserEntity>(context);
                CommonDAL<PermissionEntity> permisionDal = new CommonDAL<PermissionEntity>(context);
                //PermissionEntity permision = permisionDal.GetModel(s => s.Name == permissionName);
                //if (permision == null)
                //{
                //    throw new ArgumentException("查无：" + permissionName + "权限");
                //}

                //AdminUserEntity admin= adminDal.GetModel(UserId);
                var admin = adminDal.GetModels()
                  .Include(ss => ss.Roles).AsNoTracking()
                  .SingleOrDefault(ss => ss.Id == UserId);

                if (admin == null)
                {
                    throw new ArgumentException("id：" + UserId + "不存在");
                }


                //if (adminResult.Count()==0)
                //{
                //    throw new ArgumentException("id：" + UserId + "不存在");
                //}
                //else if(adminResult.Count()>1)
                //{
                //    throw new ApplicationException("id：" + UserId + "存在多条记录");
                //}

                //return admin.Roles.Any(s => s.Permissions.Any(p => p.Name == permissionName));
                return admin.Roles.SelectMany(s => s.Permissions).Any(s => s.Name == permissionName);//查询第二次了
            }
        }
        /// <summary>
        /// 是否有该Id权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="permisionId"></param>
        /// <returns></returns>
        public bool HasPermission(long UserId, long permisionId)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                CommonDAL<AdminUserEntity> adminDal = new CommonDAL<AdminUserEntity>(context);
                CommonDAL<PermissionEntity> permisionDal = new CommonDAL<PermissionEntity>(context);
                var admin = adminDal.GetModels()
                  .Include(ss => ss.Roles).AsNoTracking()
                  .SingleOrDefault(ss => ss.Id == UserId);

                if (admin == null)
                {
                    throw new ArgumentException("id：" + UserId + "不存在");
                }
                return admin.Roles.SelectMany(s => s.Permissions).Any(s => s.Id == permisionId);//查询第二次了
            }
        }
        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(long Id)
        {
            using (DbContextZSZ context = new DbContextZSZ())
            {
                AdminUserEntity admin = new AdminUserEntity { Id = Id };
                context.Entry(admin).State = System.Data.Entity.EntityState.Deleted;
                return context.SaveChanges() > 0;
            }
        }
    }
}
