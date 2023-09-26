using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Data.Repository.IRepository
{
    public interface IRepositry<T> where T : class
    {   
        Task<IEnumerable<T>> GetAll();
        Task <T?> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task CompLetAsync();




    } 
}