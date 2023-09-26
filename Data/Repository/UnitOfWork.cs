//using Microsoft.Extensions.Logging;
//using MyApp.Data.Repository.IRepository;
//using MyApp.Application.services.Users;
//using MyApp.Domain.Cars;
//using MyApp.Domain.Users;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyApp.Data.Repository
//{
//    public class UnitOfWork : IUnitOfWork, IDisposable
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly ILogger _logger;

//        public IUserServices Users { get; private set; }
//        public UnitOfWork(
//            ApplicationDbContext context,
//            ILoggerFactory loggerFactory)
//        {
//            _context = context;
//            var _logger = loggerFactory.CreateLogger("logs");
//            Users = new UserServices(_context,_logger);
//        }
//        public Task CompLetAsync()
//        {
//           return _context.SaveChangesAsync();
//        }

//        public int Complete()
//        { 
//            return _context.SaveChanges();
//        }

//        public void Dispose()
//        {
//            _context.Dispose(); 
//        }


       
//    }
//}
