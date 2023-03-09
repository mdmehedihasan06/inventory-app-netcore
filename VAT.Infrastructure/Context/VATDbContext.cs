using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAT.Infrastructure.Context
{
	public class VATDbContext:DbContext
	{
		public VATDbContext(DbContextOptions<VATDbContext> options) : base(options)
		{
		}
	}
}
