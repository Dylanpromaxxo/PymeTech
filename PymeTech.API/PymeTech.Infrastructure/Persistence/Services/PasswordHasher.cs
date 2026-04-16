using Microsoft.AspNetCore.Identity;
using PymeTech.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly Microsoft.AspNetCore.Identity.PasswordHasher<object> _hasher
        = new Microsoft.AspNetCore.Identity.PasswordHasher<object>();
        public string Hash(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool Verify(string password, string hash)
        {
            var result = _hasher.VerifyHashedPassword(null, hash, password);
            return result == PasswordVerificationResult.Success ||
                   result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
