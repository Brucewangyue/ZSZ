using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{

    public class DbContextZSZ : DbContext
    {
        private static ILog _log = LogManager.GetLogger(typeof(DbContextZSZ));

        public DbContextZSZ() : base("name=zszcon")
        {
            //监控性能
            this.Database.Log = sql => _log.DebugFormat("$*EF执行SQL*$：{0}",sql);
            //单元测试
            //this.Database.Log = sql => Console.WriteLine(sql);
            //禁止Migration
             Database.SetInitializer<DbContextZSZ>(null);
        }

        public DbSet<SettingEntity> Settings { get; set; }
        public DbSet<AdminLogEntity> AdminLogs { get; set; }
        public DbSet<AttachmentEntity> Attachments { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<CommunityEntity> Communitys { get; set; }
        public DbSet<DictionaryEntity> Dictionarys { get; set; }
        public DbSet<HouseAppointmentEntity> HouseAppointments { get; set; }
        public DbSet<HouseEntity> Houses { get; set; }
        public DbSet<HousePicEntity> HousePics { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdminUserEntity> AdminUsers { get; set; }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
