using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
	public class EmpProfileRepository : IRepository<EmpProfile>
	{
		private readonly EmployeeDbContext context;

		public EmpProfileRepository(EmployeeDbContext dbContext)
		{
			this.context = dbContext;
		}

		public IEnumerable<EmpProfile> GetAll()
		{
			return context.EmpProfiles.ToList();
		}

		public EmpProfile GetById(int id)
		{
			return context.EmpProfiles.Find(id);
		}

		public void Insert(EmpProfile entity)
		{
			context.EmpProfiles.Add(entity);
			Save();
		}

		public void Update(EmpProfile entity)
		{
			context.Entry(entity).State = EntityState.Modified;
			Save();
		}

		public void Delete(int id)
		{
			var entity = context.EmpProfiles.Find(id);
			if (entity != null)
			{
				context.EmpProfiles.Remove(entity);
				Save();
			}
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}
}
