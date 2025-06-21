using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artha.Backend.Domain.Contract.Interface;
using Artha.Backend.Domain.Entity;
using System;

namespace Artha.Backend.Persistence.Repository
{
    /// <summary>
    /// Repository implementation for TradeableEtfEntity operations.
    /// </summary>
    public class TradeableEtfRepository : ITradeableEtfRepository
    {
        private readonly ArthaDbContext _context;

        public TradeableEtfRepository(ArthaDbContext context)
        {
            _context = context;
        }

        public async Task<TradeableEtfEntity> CreateAsync(TradeableEtfEntity entity)
        {
            try
            {
                _context.TradeableEtfs.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TradeableEtfEntity>> CreateAsync(IEnumerable<TradeableEtfEntity> entities)
        {
            try
            {
                _context.TradeableEtfs.AddRange(entities);
                await _context.SaveChangesAsync();
                return entities;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TradeableEtfEntity?> GetEtfBySymbolAndExchangeAsync(string symbol, string exchange)
        {
            try
            {
                return await _context.TradeableEtfs.FirstOrDefaultAsync(e => e.Symbol == symbol && e.Exchange == exchange);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TradeableEtfEntity>> GetAllTradeableEtfsAsync()
        {
            try
            {
                return await _context.TradeableEtfs.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
