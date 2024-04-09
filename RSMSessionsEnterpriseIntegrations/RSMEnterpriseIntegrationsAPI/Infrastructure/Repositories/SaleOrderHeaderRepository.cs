namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SaleOrderHeaderRepository : ISalesOrderHeaderRepository
    {
        private readonly AdvWorksDbContext _context;
        public SaleOrderHeaderRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            await _context.AddAsync(salesOrderHeader);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            _context.Remove(salesOrderHeader);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SalesOrderHeader>> GetAllSalesOrderHeader(int pageNumber, int pageSize)
        {
            return await _context.SalesOrderHeader
                    .AsNoTracking()
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                 .ToListAsync();
        }

        public async Task<SalesOrderHeader?> GetSalesOrderHeaderById(int id)
        {
            return await _context.SalesOrderHeader
                .AsNoTracking()
                .FirstOrDefaultAsync(d=>d.SalesOrderId == id);
        }

        public async Task<int> UpdateSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            _context.Update(salesOrderHeader);

            return await _context.SaveChangesAsync();
        }
    }
}
