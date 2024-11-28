using HMSWithLayers.Application.DTOS;
using HMSWithLayers.Core.Result;
using HMSWithLayers.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSWithLayers.Application.Contracts;

public interface IOrderService : IApplicationService, IScopedService
{
    Task<Result<List<OrderResponseDto>>> GetAllOrdersAsync(Status status);
    Task<Result<OrderResponseDto>> GetOrderByIdAsync(int id);
    Task<Result> AddOrderAsync(OrderRequestDto orderRequestDto);
    Task<Result<OrderResponseDto>> UpdateOrderStatusAsync(int id , Status status);
}
