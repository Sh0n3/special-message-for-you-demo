using AutoMapper;
using DbManagment.Context;
using DbManagment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Schema
{
	public class Mutation
	{
		public async Task<UserResult> CreateUser([Service] DbContextSMFY dbContextSMFY, [Service] IMapper mapper, string userName, string userEmail, string userPassword)
		{
			User newUser = new User()
			{
				UserName = userName,
				UserEmail = userEmail,
				UserPassword = userPassword
			};
			await dbContextSMFY.AddAsync(newUser);
			await dbContextSMFY.SaveChangesAsync();
			return mapper.Map<UserResult>(newUser);
		}
		public async Task<UserResult> UpdateUser([Service] DbContextSMFY dbContextSMFY, [Service] IMapper mapper, int userId, string userName, string userEmail, string userPassword)
		{
			User userToUpdate = await dbContextSMFY.Users.FirstOrDefaultAsync(user => user.UserID.Equals(userId));
			if(userToUpdate is null)
			{
				throw new GraphQLException(new Error("User was not found!"));
			}
			userToUpdate.UserName = userName;
			userToUpdate.UserEmail = userEmail;
			userToUpdate.UserPassword = userPassword;
			await dbContextSMFY.SaveChangesAsync();
			return mapper.Map<UserResult>(userToUpdate);
		}
		public async Task<UserResult> DeleteUser([Service] DbContextSMFY dbContextSMFY, [Service] IMapper mapper, int userId)
		{
			User userToDelete = await dbContextSMFY.Users.FirstOrDefaultAsync(x => x.UserID == userId);
			if(userToDelete is null)
			{
				throw new GraphQLException(new Error("User was not Found!"));
			}
			dbContextSMFY.Users.Remove(userToDelete);
			await dbContextSMFY.SaveChangesAsync();
			return mapper.Map<UserResult>(userToDelete);
		}
	}
}
