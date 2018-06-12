using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.ZSZ.Entity;
using System.Linq.Expressions;
namespace Y.ZSZ.DAL
{
    public class CommonDAL<T> where T : BaseEntity
    {
        private DbContext _context;
        public CommonDAL(DbContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// 获取所有未软删除数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetModels()
        {
            return _context.Set<T>().Where(s => s.IsDelete == false);
        }
        /// <summary>
        /// 获取所有未软删除数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetModels(Expression<Func<T,bool>> whereLambda)
        {
            return _context.Set<T>().Where(s => s.IsDelete == false).Where(whereLambda);
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetModel(long id)
        {
            T entity = _context.Set<T>().FirstOrDefault(s => s.Id == id && s.IsDelete == false);
            return entity;
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> whereLambda)
        {
            T entity = _context.Set<T>().Where(whereLambda).FirstOrDefault(s => s.IsDelete == false);
            return entity;
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetSingleById(long Id)
        {
            T entity = _context.Set<T>().SingleOrDefault(s => s.Id == Id && s.IsDelete == false);
            return entity;
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetSingle(Expression<Func<T, bool>> whereLambda)
        {
            T entity = _context.Set<T>().Where(whereLambda).SingleOrDefault(s=>s.IsDelete == false);
            return entity;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> whereLambda)
        {
            return _context.Set<T>().Where(s=>s.IsDelete==false).Any(whereLambda);
        }
        /// <summary>
        /// 修改为删除标记
        /// </summary>
        /// <param name="Id"></param>
        public void MarkDelete(long Id)
        {
            T entity = _context.Set<T>().FirstOrDefault(s =>s.Id== Id &&  s.IsDelete == false);
            if (entity == null)
            {
                throw new ArgumentException("找不到Id为：" + Id + "的数据");
            }

            entity.IsDelete = true;
            entity.DeleteDate = DateTime.Now;
            //_context.SaveChanges();
        }
    }
}
