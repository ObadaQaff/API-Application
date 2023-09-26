using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using MyApp.Data;
using MyApp.Application.services;
using MyApp.Data.Repository.IRepository;
using MyApp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyApp.Data.Repository;
using AutoMapper;

namespace MyApp.Application.services.Users; 
    



public interface IUserServices 
{    
   
    public Task<IEnumerable<User>> GetAll();
    Task<bool> Add(User user);
    Task<User?> GetById(int id);
    Task<bool> Delete(User user);
    Task<bool> Update(User user);
    Task Save();



}
public class UserServices :IUserServices
{
    private readonly IMapper _mapper;

    public UserServices( IRepositry<User>  repositry, ApplicationDbContext context,IMapper mapper)  
    {
        _repositry = repositry;
        _mapper= mapper;
    }

    public IRepositry<User> _repositry { get; }

    public Task<bool> Add(User user)
    {

        try
        {

            _repositry.Add(user);
            return (Task.FromResult(true));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;


        }
    }

    public Task<bool> Delete(User user)
    {
        try
        {

            _repositry.Delete(user);
            return (Task.FromResult(true));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;


        }
    }

    public  async Task <IEnumerable<User>> GetAll()
    {
            try
            {
            return await _repositry.GetAll();
            }
            catch(Exception ex)
            {
                    Console.WriteLine(ex);
                    throw;
        
        
            }
              
    }

    public async Task<User?> GetById(int id)
    {
        try
        {
            return await _repositry.GetById(id);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;


        }
    }


    public async Task Save()
    {
           _repositry.CompLetAsync();
        
    }

    public Task<bool> Update(User user)
    {
        try
        {

            _repositry.Update(user);
            return (Task.FromResult(true));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;


        }
    }
}




