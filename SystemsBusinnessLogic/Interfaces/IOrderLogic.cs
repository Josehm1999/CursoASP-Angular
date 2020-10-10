using Models;
using System.Collections.Generic;

namespace SystemsBusinnessLogic.Interfaces
{
    public interface IOrderLogic
    {
        IEnumerable<OrderList> GetPaginatedOrders(int page, int rows);
        OrderList GetOrderById(int orderId);
        bool Delete(Order order);
        Order GetById(int orderId);
        string GetOrderNumber(int orderId);
    }
}
