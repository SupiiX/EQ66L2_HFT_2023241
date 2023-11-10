using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public interface IReposit<T>
    {
        T Read(int id);

        IQueryable<T> ReadAll();
        
        void Update(T value);

        void Delete(int id);

    }
}
