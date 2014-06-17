using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using GP.AccesoaDatos;
using GP.Dominio;
using GP.Repositorio.Interfaces;
using Log;

namespace GP.Repositorio
{
    public abstract class BaseRepository<T> : IRepository<T> 
        where T : BaseModel
    {
        private GerenciamientoProyectosContext _gerenciamientoProyectosContext;

        protected virtual GerenciamientoProyectosContext GerenciamientoProyectosContext
        {
            get
            {
                if (_gerenciamientoProyectosContext == null)
                {
                    _gerenciamientoProyectosContext = new GerenciamientoProyectosContext();
                }
                return _gerenciamientoProyectosContext;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return (List<T>)GerenciamientoProyectosContext.Set<T>().ToList();
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return null;
            }  
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return GerenciamientoProyectosContext.Set<T>().FirstOrDefault(predicate);
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return null;
            }
        }

        public int Create(T entity)
        {
            try
            {
                GerenciamientoProyectosContext.Set<T>().Add(entity);
                return GerenciamientoProyectosContext.SaveChanges();
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return 0;
            }
        }

        public int Update(T entity)
        {
            try
            {
                GerenciamientoProyectosContext.Entry(entity).State = EntityState.Modified;
                return GerenciamientoProyectosContext.SaveChanges();
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return 0;
            }
        }

        public int Delete(T entity)
        {
            try
            {
                GerenciamientoProyectosContext.Entry(entity).State = EntityState.Deleted;
                return GerenciamientoProyectosContext.SaveChanges();
            }
            catch (Exception e)
            {
                var log = new Logger();
                log.WriteLog(e.ToString());
                return 0;
            }
        }

        public void Dispose()
        {
            if (_gerenciamientoProyectosContext != null)
            {
                _gerenciamientoProyectosContext.Dispose();
                _gerenciamientoProyectosContext = null;
            }
        }

    }
}
