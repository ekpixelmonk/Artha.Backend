using Artha.Backend.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artha.Backend.Domain.Contract.Interface
{
    /// <summary>
    /// Repository interface for ZerodhaHoldingsEntity operations.
    /// </summary>
    public interface IZerodhaHoldingsRepository
    {
        /// <summary>
        /// Inserts a single ZerodhaHoldingsEntity into the database.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The inserted entity.</returns>
        Task<ZerodhaHoldingsEntity> CreateAsync(ZerodhaHoldingsEntity entity);

        /// <summary>
        /// Inserts a list of ZerodhaHoldingsEntity into the database.
        /// </summary>
        /// <param name="entities">The list of entities to insert.</param>
        /// <returns>The list of inserted entities.</returns>
        Task<IEnumerable<ZerodhaHoldingsEntity>> CreateAsync(IEnumerable<ZerodhaHoldingsEntity> entities);
    }
}
