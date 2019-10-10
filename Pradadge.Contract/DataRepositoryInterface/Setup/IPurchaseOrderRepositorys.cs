using Pradadge.Entities.Model;
using Pradadge.ViewModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pradadge.Contract.DataRepositoryInterface.Setup
{
    public interface IPurchaseOrderRepositorys
    {
        PurchaseOrderViewModel AddPurchaseOrder(PurchaseOrderViewModel entity);
        int GetPurchaseOrderRecordId();
        int GetOrderCode();
        IEnumerable<PurchaseOrderViewModel> GetAllPurchaseOrder();
        IQueryable<PurchaseOrderViewModel> GetPurchaseOrderById(int id);
        bool UpdatePurchaseOrder(PurchaseOrderViewModel entity);
        bool DeleteOrderDetail(OrderDetailViewModel entity);
        bool UpdatePurchaseOderDetail(OrderDetailViewModel entity);
        void DeletePurchaseOrder(int id);
        OrderDetailViewModel RecieveOrder(OrderDetailViewModel entity);
        bool ReceiveAllOrders(List<OrderDetailViewModel> orders);
      //  OrderDetailViewModel SetOrderDetails(OrderDetailViewModel entity, tbl_PurchaseOrderDetail order);
    }
}
