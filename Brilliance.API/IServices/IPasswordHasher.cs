﻿namespace Brilliance.API.IServices
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}