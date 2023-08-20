﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels.DTOs;
using PersonStatisticsAPI.Models.Models;
using System.Security.Cryptography;
using System.Text;

namespace PersonStatisticsAPI.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppliacationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppliacationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> GetMemberAsync(int id)
        {
            return await _context.Users.Where(x => x.Id == id)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<UserDto> GetMemberAsync(string username)
        {
            return await _context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
            //return await user.ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            //    .FirstOrDefaultAsync();
        }

        public async Task<UserDto> Post(RegisterDto registrDto)
        {
            var user = _mapper.Map<RegisterDto, User>(registrDto);

            using var hmac = new HMACSHA512();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registrDto.Password));
            user.PasswordSalt = hmac.Key;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                UserName = user.UserName,
                Name = user.Name,
            };
        }

        public async Task<bool> UserExists(string login)
        {
            return await  _context.Users.AnyAsync(x => x.UserName == login.ToLower());
        }

    }
}
