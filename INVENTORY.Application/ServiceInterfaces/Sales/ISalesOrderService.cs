using INVENTORY.Contracts.Response;
using INVENTORY.Domain.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Application.ServiceInterfaces.Sales
{
    public interface ISalesOrderService
	{
        public Task<ApiResponse> GetAsync();
        public Task<ApiResponse> GetByIdAsync(int id);
        public Task<ApiResponse> CreatAsync(SalesOrderModel salesOrder);
        public Task<ApiResponse> UpdateAsync(SalesOrderModel salesOrder);
        public Task<ApiResponse> DeleteAsync(int id);
    }
}
