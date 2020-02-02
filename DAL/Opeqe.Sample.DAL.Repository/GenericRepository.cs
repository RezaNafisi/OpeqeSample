using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Opeqe.Sample.DAL.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        //internal Context context;
        //internal DbSet<TEntity> dbSet;

        //public GenericRepository(Context context)
        //{
        //    this.context = context;
        //    this.dbSet = context.Set<TEntity>();
        //}


        public static List<TEntity> list;
        public GenericRepository()
        {
            list = new List<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Func<TEntity, bool> filter = null,
            Func<TEntity, TEntity> orderBy = null,
            string includeProperties = "")
        {
            return list.Where(filter).OrderBy(orderBy);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAsync(
            Func<TEntity, bool> filter = null,
            Func<TEntity, TEntity> orderBy = null,
            string includeProperties = "")
        {
            IEnumerable<TEntity> tmp=null;
            await Task.Factory.StartNew(() =>
            {
                if (list != null && list.Count > 0)
                {
                    if (filter!=null)
                    {
                        tmp = list.Where(filter);
                    }
                    else
                    {
                        tmp = list;
                    }
                    
                    if (tmp!=null)
                    {
                        if (orderBy!=null)
                        {
                            tmp = tmp.OrderBy(orderBy);
                        }
                        
                    }
                }
            });
            return tmp;
        }





        public virtual void Insert(TEntity entity)
        {
            list.Add(entity);
        }

        public async virtual Task InsertAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                list.Add(entity);
            });
        }


        public virtual void Delete(TEntity entityToDelete)
        {
            list.Remove(entityToDelete);
        }
        public async virtual Task DeleteAsync(TEntity entityToDelete)
        {
            await Task.Factory.StartNew(() =>
            {
                list.Remove(entityToDelete);
            });           
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            list[list.IndexOf(entityToUpdate)] = entityToUpdate;
        }

        public async virtual Task UpdateAsync(TEntity entityToUpdate)
        {
            await Task.Factory.StartNew(() =>
            {
                list[list.IndexOf(entityToUpdate)] = entityToUpdate;
            });                
        }
    }
}
