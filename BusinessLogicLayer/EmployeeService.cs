using System.Collections.Generic;
using DataAccessLayer.Models; 
using DataAccessLayer.Data; 

namespace BusinessLogicLayer
{
	public class EmployeeService
	{
		private readonly EmpProfileRepository _empProfileRepository;

		public EmployeeService(EmpProfileRepository empProfileRepository)
		{
			_empProfileRepository = empProfileRepository;
		}

		public IEnumerable<EmpProfile> GetAllEmployees()
		{
			return _empProfileRepository.GetAll();
		}

		public EmpProfile GetEmployeeById(int employeeId)
		{
			return _empProfileRepository.GetById(employeeId);
		}

		public void SaveEmployee(EmpProfile employee)
		{
			
			_empProfileRepository.Insert(employee);
		}

		public void UpdateEmployee(EmpProfile employee)
		{
			
			_empProfileRepository.Update(employee);
		}

		public void DeleteEmployee(int employeeId)
		{
			
			_empProfileRepository.Delete(employeeId);
		}
	}
}
