using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektRestauracja.Domain.Entities;

namespace ProjektRestauracja.Domain.Abstract
{
    public interface IGenericRepository<T> {
        
        IEnumerable<T> Entities { get; }
      


        void SaveEntity(T entity);
        


        T DeleteEntity(int entityID);
        

    }
}
