using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class CartService : EcommerceServices<Cart>, ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly ICartDetailRepository cartDetailRepository;

        public CartService(IRepository<Cart> baseReponsitory, ICartRepository cartRepository, ICartDetailRepository cartDetailRepository)
            : base(baseReponsitory)
        {
            this.cartRepository = cartRepository;
            this.cartDetailRepository = cartDetailRepository;
        }

        public async Task<bool> AddCart(Guid ProductId, Guid? ProductSizeId, Guid? ProductColorId, int Quantity, Guid UserId, string LanguageId)
        {
            var product = await cartRepository.GetProductCart(ProductId, ProductSizeId, ProductColorId, LanguageId);
            var cart = cartRepository.GetFirstOrDefaultAsync(x => x.UserId == UserId && x.CartStatus == ShoppingCartEnum.PreOrder);

            if (cart == null)
            {
                if (Quantity <= product.CountStock)
                {
                    Cart cartNew = new Cart();
                    cartNew.UserId = UserId;
                    
                    if (product.PercentDiscount != 0)
                    {
                        var discountPrice = product.Price - ((product.PercentDiscount * product.Price)/100);
                        cartNew.TotalPrice = discountPrice * Quantity;
                    }
                    else
                    {
                        cartNew.TotalPrice = product.Price * Quantity;
                    }
                    await cartRepository.AddAsync(cartNew);
                    CartDetail cartDetailNew = new CartDetail();
                    cartDetailNew.CartId = cartNew.Id;
                    cartDetailNew.ProductAttributeId = product.Id;
                    cartDetailNew.Price = product.Price;
                    cartDetailNew.Quantity = Quantity;
                    cartDetailNew.ProductId = ProductId;
                    await cartDetailRepository.AddAsync(cartDetailNew);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                var cartDetail = cartDetailRepository.GetFirstOrDefaultAsync(x => x.CartId == cart.Id && x.ProductAttributeId == product.Id);
                if (cartDetail == null)
                {
                    if (Quantity <= product.CountStock)
                    {
                        CartDetail cartDetailNew = new CartDetail();
                        cartDetailNew.ProductAttributeId = product.Id;
                        cartDetailNew.CartId = cart.Id;
                        cartDetailNew.Price = product.Price;
                        cartDetailNew.Quantity = Quantity;
                        cartDetailNew.ProductId = ProductId;
                        await cartDetailRepository.AddAsync(cartDetailNew);
                        if (product.PercentDiscount != 0)
                        {
                            var discountPrice = product.Price - ((product.PercentDiscount * product.Price) / 100);
                            cart.TotalPrice += discountPrice * Quantity;
                        }
                        else
                        {
                            cart.TotalPrice += product.Price * Quantity;
                        }
                        await cartRepository.UpdateAsync(cart);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if ((cartDetail.Quantity + Quantity) <= product.CountStock)
                    {
                        cartDetail.Quantity += Quantity;
                        await cartDetailRepository.UpdateAsync(cartDetail);
                        if (product.PercentDiscount != 0)
                        {
                            var discountPrice = product.Price - ((product.PercentDiscount * product.Price) / 100);
                            cart.TotalPrice += discountPrice * Quantity;
                        }
                        else
                        {
                            cart.TotalPrice += product.Price * Quantity;
                        }
                        await cartRepository.UpdateAsync(cart);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public async Task<List<CartViewModel>> GetAllProductCart()
        {
            return await cartRepository.GetAllProductCart();
        }
    }
}
