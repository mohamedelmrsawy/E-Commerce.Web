﻿using DomianLayer.Models.BasketModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomianLayer.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string Key);
        Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket ,TimeSpan? TimeToLive = null);
        Task<bool>DeleteBasketAsync(string id);
    }
}
