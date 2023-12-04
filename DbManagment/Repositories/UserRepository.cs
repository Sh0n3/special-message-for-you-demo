using AutoMapper;
using DbManagment.Context;
using DbManagment.DTOs.Input;
using DbManagment.DTOs.Output;
using DbManagment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Repositories
{
    public class UserRepository
    {
        readonly IDbContextFactory<DbContextSMFY> _dbContextFactorySMFY;
        readonly IMapper _mapper;
        public UserRepository(IDbContextFactory<DbContextSMFY> dbContextFactorySMFY, IMapper mapper)
        {
            _dbContextFactorySMFY = dbContextFactorySMFY;
            _mapper = mapper;
        }
        public async Task<List<UserODTO>> GetUsers()
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                return await _dbContextSMFY.Users.Select(user => _mapper.Map<UserODTO>(user)).ToListAsync();
            }
        }
        public async Task<UserODTO> GetUserById(int userId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                var user = await _dbContextSMFY.Users.FirstOrDefaultAsync(user => user.UserID.Equals(userId));
                return _mapper.Map<UserODTO>(user);
            }
        }

        public async Task<UserODTO> AddUser(UserIDTO userIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                EntityEntry<User> newUser = await _dbContextSMFY.AddAsync(_mapper.Map<User>(userIDTO));
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<UserODTO>(newUser.Entity);
            }
        }

        public async Task<UserODTO> UpdateUser(UserIDTO userIDTO)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                User updateUser = _mapper.Map<UserIDTO, User>(userIDTO, await _dbContextSMFY.Users.FirstOrDefaultAsync(user => user.UserID.Equals(userIDTO.UserID)));
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<UserODTO>(updateUser);
            }
        }

        public async Task<UserODTO> DeleteUser(int userId)
        {
            using (DbContextSMFY _dbContextSMFY = _dbContextFactorySMFY.CreateDbContext())
            {
                User deleteUser = await _dbContextSMFY.Users.FirstOrDefaultAsync(user => user.UserID.Equals(userId));
                _dbContextSMFY.Remove(deleteUser);
                await _dbContextSMFY.SaveChangesAsync();
                return _mapper.Map<UserODTO>(deleteUser);
            }
        }
    }
}
