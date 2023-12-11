using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository.Interfaces
{
    public interface IReposit<T>
    {
        IQueryable<T> ReadAll();

        T Read(int id);

        void Create(T item);

        void Update(T value);

        void Delete(int id);

    }
}
