namespace Brilliance.API.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<string> Authorization(string username, CancellationToken cancellationToken);
    }
}
