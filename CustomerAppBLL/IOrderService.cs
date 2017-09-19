using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public interface IOrderService
    {
        //C
        OrderBO Create(OrderBO vid);
        //R
        List<OrderBO> GetAll();
        OrderBO Get(int Id);
        //U
        OrderBO Update(OrderBO vid);
        //D
        OrderBO Delete(int Id);
    }
}
