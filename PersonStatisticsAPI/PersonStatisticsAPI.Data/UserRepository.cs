using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonStatisticsAPI.Data.Db;
using PersonStatisticsAPI.Data.Interfaces;
using PersonStatisticsAPI.DataModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonStatisticsAPI.Data
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppliacationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppliacationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserDto Get(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<UserDto>(user);
        }

        public UserDto Get(string login)
        {
            var user = _context.Users.Where(x => x.Login == login.ToLower()).FirstOrDefault();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UserExists(string login)
        {
            return await  _context.Users.AnyAsync(x => x.Login == login.ToLower());
        }
    }
}
