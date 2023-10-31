namespace Brilliance.API.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateJwtToken(string username, string role);
    }
}