using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGS.Models
{
    public class Contact
    {
		public string firstname { get; set; }
		public string lastname { get; set; }
		 public string Email { get; set; }

		public string Phone { get; set; }

		public string Company { get; set; }

		public string subject { get; set; }
       
       public string message { get; set; }

	}
}
