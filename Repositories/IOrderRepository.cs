using Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<OrderList> getPaginatedOrder(int page, int rows);
        OrderList GetOrderById(int orderId);
    }
}
