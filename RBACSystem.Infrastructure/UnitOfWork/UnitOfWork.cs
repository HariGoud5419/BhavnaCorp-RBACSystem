using RBACSystem.Core.Interfaces;
using RBACSystem.Infrastructure.Data;
using RBACSystem.Infrastructure.Repositories;

namespace RBACSystem.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Coordinates data operations using a shared DbContext instance.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
