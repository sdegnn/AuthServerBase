using AuthServer.Core.UnıtOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data
{
    public class UnıtOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnıtOfWork(AppDbContext appDbContext)
        {
            _context=appDbContext;
            
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
