using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
	public class StudentInfo
	{
		[Key]
		public int StudeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string EmailId { get; set; }
		public string className { get; set; }
		public string Division { get; set; }
	}
}
