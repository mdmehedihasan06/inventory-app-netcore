using INVENTORY.Contracts.Response;
using INVENTORY.Domain.Dtos.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Application.ServiceInterfaces.Settings
{
	public interface ISupplierService
	{
		public Task<ApiResponse> GetAsync();
		public Task<ApiResponse> GetByIdAsync(int id);
		public Task<ApiResponse> GetForDropdownAsync();
		public Task<ApiResponse> CreatAsync(SupplierDto dto);
		public Task<ApiResponse> UpdateAsync(SupplierDto dto);
		public Task<ApiResponse> DeleteAsync(int id);
	}
}
