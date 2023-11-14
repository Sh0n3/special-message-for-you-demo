using DbManagment.Context;
using DbManagment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.GraphQLService
{
    public class Query
	{
		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public async Task<IEnumerable<User>> GetUsers([Service] DbContextSMFY contextSMFY) => await contextSMFY.Users.ToListAsync();

		[UseProjection]
		[UseFiltering]
		[UseSorting]
		public async Task<User> GetUserById([Service] DbContextSMFY contextSMFY, int userId) 
			=> await contextSMFY.Users.FirstOrDefaultAsync(x => x.UserID.Equals(userId));
	}
}
