namespace Brilliance.API.IServices
{
    public interface ITokenService
    {
        public string GenerateJwtToken(string username, string role);
    }
}