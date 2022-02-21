﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.DAL.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Mappers;
using TestingSystem.BLL.JWTAuth;

namespace TestingSystem.BLL.Services
{
    public class UserService
    {
        private readonly UnitOfWorkFactory _unitOfWorkFactory;

        public UserService()
        {
            _unitOfWorkFactory = new UnitOfWorkFactory();
        }

        public UserService(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ClaimsIdentity GetClaimsIdentity(string username, string password)
        {
            using(var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                UserDto user = unitOfWork.User.GetUserByUserNameAndPassword(username, password)?.ToDto();
                if (user == null) return null;
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
        }

        public string GetEncodedJwtToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public EntityOperationResult<UserDto> AddUser(UserDto user)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                unitOfWork.User.AddUser(user.ToModel());
                try
                {
                    unitOfWork.SaveChanges();
                }
                catch(Exception ex)
                {
                    return EntityOperationResult<UserDto>.Failture(ex.Message);
                }
                return EntityOperationResult<UserDto>.Success(user);
            }
        }
    }
}
