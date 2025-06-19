using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Artha.Backend.Domain.Contract.Interface;
using Artha.Backend.Domain.Entity;

namespace Artha.Backend.Persistence.Repository
{
    /// <summary>
    /// Implementation of IZerodhaConfigRepository for fetching ZerodhaConfig from the database.
    /// </summary>
    public class ZerodhaConfigRepository : IZerodhaConfigRepository
    {
        private readonly ArthaDbContext _context;

        public ZerodhaConfigRepository(ArthaDbContext context)
        {
            _context = context;
        }

        public async Task<ZerodhaConfig?> GetZerodhaConfigAsync()
        {
            try
            {
                // Assuming only one config row exists (ID = 1 by default)
                return await _context.ZerodhaConfig.FirstOrDefaultAsync();
            }
            catch
            {
                // Rethrow the exception to be handled by the calling service
                throw;
            }
        }
    }
}
