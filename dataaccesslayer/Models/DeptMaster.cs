using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
	public class DeptMaster
	{
		[Key]
		public int DeptCode { get; set; }

		[Required(ErrorMessage = "Department Name is required.")]
		[StringLength(50, ErrorMessage = "Department Name cannot exceed 50 characters.")]
		public string DeptName { get; set; }
	}
}
