﻿using EQ66L2_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EQ66L2_HFT_2023241.Repository
{
    public interface IOrderRepository : IReposit<Order>
    {
        void ChangeQuantity(int id, int Quantity);

        void ChangeProduct(int id, int NewProductId);

    }
}
