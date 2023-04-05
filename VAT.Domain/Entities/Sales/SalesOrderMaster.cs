using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VAT.Domain.Entities.Settings;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VAT.Domain.Entities.Sales
{
	public class SalesOrderMaster : BaseEntity
	{
		public int CustomerId { get; set; }
		//[Index(IsUnique = true)]
		public int OrderNo { get; set; }
	}
}
