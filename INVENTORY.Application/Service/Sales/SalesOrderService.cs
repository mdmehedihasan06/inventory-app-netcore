using INVENTORY.Application.ServiceInterfaces.Common;
using INVENTORY.Application.ServiceInterfaces.Sales;
using INVENTORY.Contracts.CustomException;
using INVENTORY.Contracts.Response;
using INVENTORY.Domain.Entities.Sales;
using INVENTORY.Domain.Entities.Settings;
using INVENTORY.Domain.RequestModel;
using INVENTORY.Infrastructure.Constant;
using INVENTORY.Infrastructure.Repositories.Sales;
using INVENTORY.Infrastructure.Repositories.Settings;
using INVENTORY.Infrastructure.RepositoryInterfaces.Sales;
using INVENTORY.Infrastructure.RepositoryInterfaces.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace INVENTORY.Application.Service.Sales
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly ISalesOrderMasterRepository _salesOrderMasterRepository;
        private readonly ISalesOrderDetailsRepository _salesOrderDetailsRepository;
        private readonly ISalesOrderCostRepository _salesOrderCostRepository;
        private readonly ISalesOrderPaymentRepository _salesOrderPaymentRepository;
        private readonly StaticMessages _staticMessages;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IClaimService _claimService;
        private readonly ILogger<SalesOrderService> _logger;
        public SalesOrderService(ISalesOrderMasterRepository salesOrderMasterRepository
            , ISalesOrderDetailsRepository salesOrderDetailsRepository
            , ISalesOrderCostRepository salesOrderCostRepository
            , IOptions<StaticMessages> staticMessages
            , IDateTimeProvider dateTimeProvider
            , IHttpContextAccessor httpContextAccessor
            , IClaimService claimService
            , ISalesOrderPaymentRepository salesOrderPaymentRepository
            , ILogger<SalesOrderService> logger)
        {
            _salesOrderMasterRepository = salesOrderMasterRepository;
            _salesOrderDetailsRepository = salesOrderDetailsRepository;
            _salesOrderCostRepository = salesOrderCostRepository;
            _staticMessages = staticMessages.Value;
            _dateTimeProvider = dateTimeProvider;
            _httpContextAccessor = httpContextAccessor;
            _claimService = claimService;
            _salesOrderPaymentRepository= salesOrderPaymentRepository;
            _logger = logger;
        }

        public async Task<ApiResponse> GetAsync()
        {
            var response = await _salesOrderMasterRepository.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
            return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = string.Empty, Data = response };
        }
        public async Task<ApiResponse> GetByIdAsync(int id)
        {
            var response = await _salesOrderMasterRepository.GetAsync(x => x.Id == id && x.IsActive == true && x.IsDeleted == false);
            return new ApiResponse { StatusCode = StatusCodes.Status200OK, Message = string.Empty, Data = response };
        }

        public async Task<ApiResponse> CreatAsync(SalesOrderModel salesOrder)
        {
            var masterResponse = new SalesOrderMaster();
            using (var scope = new TransactionScope())
            {
                try
                {
                    var userId  = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                    var userName = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.GivenName.ToString()));

					_logger.LogInformation("Attempt to create Order by "+ userName);
                    if (salesOrder.SalesOrderMaster is null)
                        throw new CustomException(_staticMessages.MandatoryFieldMissing, HttpStatusCode.ExpectationFailed);
                    salesOrder.SalesOrderMaster.CreatedBy = userId;
                    salesOrder.SalesOrderMaster.CreatedDate = _dateTimeProvider.UtcNow;
                    masterResponse = await _salesOrderMasterRepository.AddAsync(salesOrder.SalesOrderMaster);

                    if (salesOrder.SalesOrderDetails is null)
						throw new CustomException(_staticMessages.MandatoryFieldMissing, HttpStatusCode.ExpectationFailed);
					foreach (var item in salesOrder.SalesOrderDetails)
                    {
                        item.SalesOrderMasterId = masterResponse.Id;
                        var detailsResponse = await _salesOrderDetailsRepository.AddAsync(item);
                    }
                    if (salesOrder.SalesOrderCosts is null)
                        throw new CustomException(_staticMessages.MandatoryFieldMissing, HttpStatusCode.ExpectationFailed);
                    foreach (var item in salesOrder.SalesOrderCosts)
                    {
                        item.SalesOrderMasterId = masterResponse.Id;
                        var detailsResponse = await _salesOrderCostRepository.AddAsync(item);
                    }
                    if (salesOrder.SalesOrderPayments is null)
                        throw new CustomException(_staticMessages.MandatoryFieldMissing, HttpStatusCode.ExpectationFailed);
                    foreach (var item in salesOrder.SalesOrderPayments)
                    {
                        item.SalesOrderMasterId = masterResponse.Id;
                        var detailsResponse = await _salesOrderPaymentRepository.AddAsync(item);
                    }

                    scope.Complete();
                }
                catch (Exception)
                {
					_logger.LogInformation("Order Creation attempt failed ");
					scope.Dispose();
                    throw;
                }
            }
            return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataSavedSuccessfully, Data = masterResponse };
        }
        public async Task<ApiResponse> UpdateAsync(SalesOrderModel salesOrder)
        {
            var masterResponse = new SalesOrderMaster();
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (salesOrder.SalesOrderMaster is null)
                        throw new Exception();
                    salesOrder.SalesOrderMaster.UpdatedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                    salesOrder.SalesOrderMaster.UpdatedDate = _dateTimeProvider.UtcNow;
                    masterResponse = await _salesOrderMasterRepository.UpdateAsync(salesOrder.SalesOrderMaster);

                    if (salesOrder.SalesOrderDetails is null)
                        throw new Exception();
                    var detailsToDelete = await _salesOrderDetailsRepository.GetAsync(x => x.SalesOrderMasterId == salesOrder.SalesOrderMaster.Id);
                    foreach (var item in detailsToDelete)
                    {
                        item.IsDeleted = true;
                        item.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                        item.DeletedDate = _dateTimeProvider.UtcNow;
                        var detailsResponse = await _salesOrderDetailsRepository.UpdateAsync(item);
                    }
                    foreach (var item in salesOrder.SalesOrderDetails)
                    {
                        item.SalesOrderMasterId = masterResponse.Id;
                        var detailsResponse = await _salesOrderDetailsRepository.AddAsync(item);
                    }

                    if (salesOrder.SalesOrderCosts is null)
                        throw new Exception();
                    var costsToDelete = await _salesOrderCostRepository.GetAsync(x => x.SalesOrderMasterId == salesOrder.SalesOrderMaster.Id);
                    foreach (var item in costsToDelete)
                    {
                        item.IsDeleted = true;
                        item.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                        item.DeletedDate = _dateTimeProvider.UtcNow;
                        var detailsResponse = await _salesOrderCostRepository.UpdateAsync(item);
                    }
                    foreach (var item in salesOrder.SalesOrderCosts)
                    {
                        item.SalesOrderMasterId = masterResponse.Id;
                        var detailsResponse = await _salesOrderCostRepository.AddAsync(item);
                    }

                    scope.Complete();
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }
            return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataUpdatedSuccessfully, Data = masterResponse };
        }
        public async Task<ApiResponse> DeleteAsync(int id)
        {
            var masterResponse = new SalesOrderMaster();
            using (var scope = new TransactionScope())
            {
                try
                {
                    var orderDetails = await _salesOrderDetailsRepository.GetAsync(m=>m.SalesOrderMasterId == id);
                    foreach (var item in orderDetails)
                    {
                        item.IsDeleted = true;
                        item.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                        item.DeletedDate = _dateTimeProvider.UtcNow;
                        await _salesOrderDetailsRepository.DeleteAsync(item);
                    }
                    
                    var orderCosts = await _salesOrderCostRepository.GetAsync(m => m.SalesOrderMasterId == id);
                    foreach (var item in orderCosts)
                    {
                        item.IsDeleted = true;
                        item.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                        item.DeletedDate = _dateTimeProvider.UtcNow;
                        await _salesOrderCostRepository.DeleteAsync(item);
                    }
                    
                    var orderMaster = await _salesOrderMasterRepository.GetByIdAsync(id);
                    orderMaster.IsDeleted = true;
                    orderMaster.DeletedBy = Convert.ToInt32(_claimService.GetClaimValue(ClaimTypes.NameIdentifier.ToString()));
                    orderMaster.DeletedDate = _dateTimeProvider.UtcNow;
                    await _salesOrderMasterRepository.DeleteAsync(orderMaster);

                    scope.Complete();
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }
            return new ApiResponse { StatusCode = (int)HttpStatusCode.OK, Message = _staticMessages.DataDeletedSuccessfully, Data = null };
        }

    }
}
