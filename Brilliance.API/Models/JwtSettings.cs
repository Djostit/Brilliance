namespace Brilliance.API.Models
{
    public record JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

    }
}