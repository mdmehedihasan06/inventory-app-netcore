using INVENTORY.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTORY.Domain.RequestModel
{
    public class SalesOrderModel
    {
        public SalesOrderMaster? SalesOrderMaster { get; set; }
        public List<SalesOrderDetails>? SalesOrderDetails { get; set; }
        public List<SalesOrderCost>? SalesOrderCosts { get; set; }
        public List<SalesOrderPayment>? SalesOrderPayments { get; set; }
    }
}
