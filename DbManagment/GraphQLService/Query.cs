using DbManagment.Context;
using DbManagment.Entities;
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
		public IQueryable<User> GetUsers([Service] DbContextSMFY contextSMFY) => contextSMFY.Users;
	}
}
