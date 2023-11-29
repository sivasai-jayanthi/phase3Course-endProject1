using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
	public class EmployeeDbContext : DbContext
	{
		public EmployeeDbContext() : base("name=EmployeeDbContext") { }
		public DbSet<DeptMaster> DeptMasters { get; set; }
		public DbSet<EmpProfile> EmpProfiles { get; set; }
	}
}
