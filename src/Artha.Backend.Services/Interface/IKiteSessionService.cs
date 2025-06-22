using System.Threading.Tasks;
using KiteConnect;

namespace Artha.Backend.Services.Interface
{
    /// <summary>
    /// Service interface for managing Kite user session for Zerodha.
    /// </summary>
    public interface IKiteSessionService
    {
        /// <summary>
        /// Initializes the Kite session and returns the login URL for user authentication.
        /// </summary>
        /// <returns>The login URL for the user to authenticate and obtain the request token.</returns>
        Task<string> InitializeKiteSessionAndGetLoginUrlAsync();

        /// <summary>
        /// Completes the Kite session by generating the user session using the request token.
        /// </summary>
        /// <param name="requestToken">The request token obtained after user login.</param>
        /// <returns>True if the session is successfully generated; otherwise, false.</returns>
        Task<bool> GenerateKiteUserSessionAsync(string requestToken);

        /// <summary>
        /// Gets the Kite instance for the current session.
        /// </summary>
        Kite? Kite { get; }
    }
}
