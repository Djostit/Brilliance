namespace Brilliance.API.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateJwtToken(int id, string role);
    }
}