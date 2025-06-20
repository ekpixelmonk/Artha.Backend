using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artha.Backend.Domain.Contract.Interface;
using Artha.Backend.Domain.Entity;
using System;

namespace Artha.Backend.Persistence.Repository
{
    /// <summary>
    /// Repository implementation for ZerodhaTradeableInstrumentEntity operations.
    /// </summary>
    public class ZerodhaTradeableInstrumentRepository : IZerodhaTradeableInstrumentRepository
    {
        private readonly ArthaDbContext _context;

        public ZerodhaTradeableInstrumentRepository(ArthaDbContext context)
        {
            _context = context;
        }

        public async Task<ZerodhaTradeableInstrumentEntity> CreateAsync(ZerodhaTradeableInstrumentEntity entity)
        {
            try
            {
                _context.ZerodhaTradeableInstruments.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                // Rethrow the exception to be handled by the calling service
                throw;
            }
        }

        public async Task<IEnumerable<ZerodhaTradeableInstrumentEntity>> CreateAsync(IEnumerable<ZerodhaTradeableInstrumentEntity> entities)
        {
            try
            {
                // Truncate the table before inserting new data
                await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [ZerodhaTradeableInstruments]");
                _context.ZerodhaTradeableInstruments.AddRange(entities);
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
