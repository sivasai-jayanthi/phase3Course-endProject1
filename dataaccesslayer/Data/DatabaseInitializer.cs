using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
	public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
	{
		protected override void Seed(EmployeeDbContext context)
		{
			// Add default data to DeptMaster table
			// Example:
			context.DeptMasters.Add(new DeptMaster { DeptCode = 1, DeptName = "IT" });
			context.DeptMasters.Add(new DeptMaster { DeptCode = 2, DeptName = "HR" });

			base.Seed(context);
		}
	}
}
