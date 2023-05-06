using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.Dtos.Settings
{
	public class CustomerDto
    {
		public string? CustomerName { get; set; }
		public string? Address { get; set; }
		public string? BillingAddress { get; set; }
		public string? DeliveryAddress { get; set; }
		public string? BinNo { get; set; }
		public string? TinNo { get; set; }
		public string? NidNo { get; set; }
		public string? ContactPerson { get; set; }
		public string? CpDesignation { get; set; }
		public string? CpDepartment { get; set; }
		public string? CpMobile { get; set; }
		public string? CpEmail { get; set; }
		public DateTime OpeningDate { get; set; }
		public decimal OpeningAmount { get; set; }
		public string? CustomerType { get; set; }
	}
}
