using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure.Persistence.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateToken(Usuario usuario)
        {
            var claims = new[]
        {
            new Claim("IdUsuario", usuario.IdUsuario.ToString()),
            new Claim("IdTenant", usuario.IdTenant.ToString()),
            new Claim("Email", usuario.Email),
            new Claim("Nombre", usuario.Nombre),
            new Claim(ClaimTypes.Role, usuario.Rol.NombreRol)
        };

            // 2. Clave secreta para firmar el token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]) 
            );
            // 3. Algoritmo de firma
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4. Construcción del token
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(_configuration["JwtSettings:ExpiryMinutes"])
                ),
                signingCredentials: credentials
            );

            // 5. Serializa el token a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
