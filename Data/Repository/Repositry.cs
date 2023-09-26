using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using MyApp.Data.Repository.IRepository;
namespace MyApp.Data.Repository
{
    public class Repositry<T> : IRepositry<T> where T : class
    {
        protected ApplicationDbContext _context;
        internal DbSet<T> dbSet;
       


        public Repositry(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>(); ;
             
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
          return  await dbSet.ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual  async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public virtual async Task CompLetAsync()
        {
            _context.SaveChanges();
        }
    }

   



}
