using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public abstract class Reposit<T> : IReposit<T> where T : class
    {

        public DBContext dbContext;

        public Reposit(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(int id)
        {
           // dbContext.Remove(id);
            
            dbContext.Set<T>().Remove(Read(id));
            dbContext.SaveChanges();
        }

        public abstract T Read(int id);

        public IQueryable<T> ReadAll()
        {
            return dbContext.Set<T>();
        }

        public void Update(T value)
        {

            //dbContext.Update(value);

            dbContext.Set<T>().Add(value);
            dbContext.SaveChanges();
        }
    }
}
