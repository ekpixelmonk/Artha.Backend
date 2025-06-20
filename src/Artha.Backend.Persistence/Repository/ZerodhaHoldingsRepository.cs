using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artha.Backend.Domain.Contract.Interface;
using Artha.Backend.Domain.Entity;
using System;

namespace Artha.Backend.Persistence.Repository
{
    /// <summary>
    /// Repository implementation for ZerodhaHoldingsEntity operations.
    /// </summary>
    public class ZerodhaHoldingsRepository : IZerodhaHoldingsRepository
    {
        private readonly ArthaDbContext _context;

        public ZerodhaHoldingsRepository(ArthaDbContext context)
        {
            _context = context;
        }

        public async Task<ZerodhaHoldingsEntity> CreateAsync(ZerodhaHoldingsEntity entity)
        {
            try
            {
                _context.ZerodhaHoldings.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                // Rethrow the exception to be handled by the calling service
                throw;
            }
        }

        public async Task<IEnumerable<ZerodhaHoldingsEntity>> CreateAsync(IEnumerable<ZerodhaHoldingsEntity> entities)
        {
            try
            {
                // Truncate the table before inserting new data
                await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [ZerodhaHoldings]");
                _context.ZerodhaHoldings.AddRange(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {
                // Rethrow the exception to be handled by the calling service
                throw;
            }
        }
    }
}
