using Models;
using System.Collections.Generic;
using System.Linq;
using SystemsBusinnessLogic.Interfaces;
using UnitOfWork;

namespace SystemsBusinnessLogic.Implementations
{
    public class OrderLogic: IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Order order)
        {
            return _unitOfWork.Order.Delete(order);
        }

        public Order GetById(int orderId)
        {
            return _unitOfWork.Order.GetById(orderId);
        }

        public OrderList GetOrderById(int orderId)
        {
            return _unitOfWork.Order.GetOrderById(orderId);
        }

        public IEnumerable<OrderList> GetPaginatedOrders(int page, int rows)
        {
            return _unitOfWork.Order.getPaginatedOrder(page, rows);
        }


        public string GetOrderNumber (int orderId)
        {
            var list = _unitOfWork.Order.GetList();
            var registro = list.First(x => x.Id == orderId);
            return registro.OrderNumber;
        }
    }
}
