using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class EmpProfile
	{
		[Key]
		public int EmpCode { get; set; }

		[Required(ErrorMessage = "Employee Name is required.")]
		public string EmpName { get; set; }

		[Required(ErrorMessage = "Date of Birth is required.")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Department Code is required.")]
		public int DeptCode { get; set; }
	}
}
