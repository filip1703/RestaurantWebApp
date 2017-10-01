using System;
using System.Collections.Generic;
using System.Data.Entity;
using ProjektRestauracja.Domain.Abstract;
using ProjektRestauracja.Domain.Entities;
using System.Linq;
using System.Web;

namespace ProjektRestauracja.Domain.Concrete {
    public class GenericRepository<T> : 
        IGenericRepository<T>  where T: class {

        private EFDbContext context = new EFDbContext();
        public EFDbContext Context { get { return context; } set { context = value; } }

        public virtual IEnumerable<T> Entities {
            get {
                IEnumerable<T> entities = Context.Set<T>();
                
                return entities;
            }
        }

        

        public virtual void SaveEntity(T entity) {
            
           
            //if (getID(entity) == 0) {
                Context.Set<T>().Add(entity);
            //}
            //else {
                
                    //Context.Entry<T>(entity).State = EntityState.Modified;
               
            //}
            Context.SaveChanges();
        }

        public virtual T DeleteEntity(int entityID) {

            T entity = Context.Set<T>().Find(entityID);

            if (entity != null) {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
            }
            return entity;
        }

    }
}