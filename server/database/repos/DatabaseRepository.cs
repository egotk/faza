using Microsoft.EntityFrameworkCore;
using test_Faza.database.config;
using test_Faza.database.entities;
using test_Faza.database.repos.interfaces;

namespace test_Faza.database.repos
{
    internal class DatabaseRepository : IDatabaseRepository
    {
        private ApplicationContext _context;

        public DatabaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public T? Create<T>(T entity) where T : BaseEntity
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T? Read<T>(int id) where T : BaseEntity
        {
            try
            {
                T? entity = _context.Set<T>().Find(id);
                if (entity != null)
                {
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T? Update<T>(T entity) where T : BaseEntity
        {
            try
            {
                T? originalEntity = _context.Set<T>().Find(entity.Id);
                if (originalEntity != null)
                {
                    _context.Entry(originalEntity).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return originalEntity;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete<T>(int id) where T : BaseEntity
        {
            try
            {
                T? entity = _context.Set<T>().Find(id);
                if (entity != null)
                {
                    _context.Set<T>().Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Interface> ReadAllIncluding()
        {
            try
            {
                return _context.Interfaces.Include(i => i.Devices).ThenInclude(d => d.Registers).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<int> ReadRegisterIds()
        {
            try
            {
                List<int> registerIds =
                    _context.Registers
                    .Select(r => r.Id)
                    .ToList();
                return registerIds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public List<RegisterValue> CreateMultipleValues(List<RegisterValue> values)
        {
            try
            {
                _context.RegisterValues.AddRange(values);
                _context.SaveChanges();
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RegisterValue> GetValuesHistory(Register register, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<RegisterValue> values = _context.RegisterValues.Where(value => (value.RegisterId == register.Id) && (value.Timestamp > startDate) && value.Timestamp < endDate).ToList();
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Log> GetLatestLogs()
        {
            try
            {
                return _context.Logs.OrderByDescending(l => l.Timestamp).Take(1000).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
