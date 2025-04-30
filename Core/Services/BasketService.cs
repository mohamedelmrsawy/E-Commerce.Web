using AutoMapper;
using DomianLayer.Contracts;
using DomianLayer.Exceptions;
using DomianLayer.Models.BasketModules;
using ServiceAbstraction;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BasketService(IBasketRepository _basketRepository, IMapper _mapper) : IBasketService
    {
        public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
        {
            var CustomerBasket = _mapper.Map<BasketDto, CustomerBasket>(basket);
            var CreateOrUpdatedBasket =await _basketRepository.CreateOrUpdateBasketAsync(CustomerBasket);
            if (CreateOrUpdatedBasket is not null)
                return await GetBasketAsync(basket.Id);
            else
                throw new Exception("!!!!!!!!!!!!!");
        }

        public async Task<bool> DeletedBasketAsync(string Key) => await _basketRepository.DeleteBasketAsync(Key);
        

        public async Task<BasketDto> GetBasketAsync(string Key)
        {
            var basket =await _basketRepository.GetBasketAsync(Key);
            if (basket is not null)
                return _mapper.Map<CustomerBasket, BasketDto>(basket);
            else
                throw new BasketNotFoundException(Key);
        }
    }
}
