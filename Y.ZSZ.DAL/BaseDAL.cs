using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.Entity;

namespace Y.ZSZ.DAL
{
    public abstract class BaseDAL<T> where T : BaseEntity
    {
        private DbContextZSZ Context = new DbContextZSZ();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public long ADD(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            Context.Dispose();
            return entity.Id;
        }
        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetModel(long Id)
        {
            T entity = Context.Set<T>().FirstOrDefault(s=>s.Id==Id && s.IsDelete==false);
            if (entity==null)
            {
                throw new ArgumentException("无此条数据，查询失败");
            }
            Context.Dispose();
            return entity;
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetModels()
        {
            IEnumerable<T> list = Context.Set<T>().Where(s => s.IsDelete == false).ToList();
            Context.Dispose();
            return list;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool MarkDelete(long Id)
        {
            T entity = Context.Set<T>().FirstOrDefault(s=>s.IsDelete==false);
            if (entity==null)
            {
                throw new ArgumentException("无此条数据，删除失败");
            }
            entity.IsDelete = true;
            entity.DeleteDate = DateTime.Now;
            int result= Context.SaveChanges();
            Context.Dispose();
            return result>0;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderWhere"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IEnumerable<T> GetPageModels(int pageIndex,int pageSize,System.Linq.Expressions.Expression<Func<T,bool>> orderWhere,bool isAsc)
        {

            var list = Context.Set<T>().Where(s => s.IsDelete == false);
            if (isAsc)
            {
                list.OrderBy(orderWhere);
            }
            else
            {
                list.OrderBy(orderWhere);
            }
            list.Skip(pageIndex).Take(pageSize).ToList();
            return list;
        }
    }
}

