using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Enums
{
    public enum OrderStatusEnum
    {
        Pending,//1-đang chờ xử lý
        AwaitingPayment,//2-đang chờ thanh toán
        AwaitingShipment,//3-đang chờ giao hàng
        AwaitingPickup,//4-đang chờ nhận
        Completed,//5-đã hoàn tất
        Shipped,//6-đã vận chuyển
        Cancelled,//7-đã hủy
        Declined,//8-đã từ chối
        Refunded,//9-đã hoàn lại
    }
}
