using AutoMapper;
using DomianLayer.Contracts;
using DomianLayer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager(IUnitOfWork _unitOfWork,IMapper _mapper, IBasketRepository basketRepository,UserManager<ApplicationUser> userManager) : IServiceManager
    {
        private readonly Lazy<IProductService> _LazyproductService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        public IProductService productService => _LazyproductService.Value;

        private readonly Lazy<IBasketService> _LazyBasketService = new Lazy<IBasketService>(() => new BasketService(basketRepository, _mapper));
        public IBasketService basketService => _LazyBasketService.Value;

        private readonly Lazy<IAuthenticationService> _LazyAuthenticationService = new Lazy<IAuthenticationService>(()=> new AuthenticationService(userManager));
        public IAuthenticationService authenticationService => _LazyAuthenticationService.Value;
    }
}
