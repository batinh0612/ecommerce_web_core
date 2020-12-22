using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using EcommerceCommon.Infrastructure.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class CartService : EcommerceServices<Cart>, ICartService
    {
        private readonly ICartRepository cartRepository;
        private readonly ICartDetailRepository cartDetailRepository;
        private readonly IProductRepository productRepository;

        public CartService(IRepository<Cart> baseReponsitory, ICartRepository cartRepository,
            ICartDetailRepository cartDetailRepository,
            IProductRepository productRepository)
            : base(baseReponsitory)
        {
            this.cartRepository = cartRepository;
            this.cartDetailRepository = cartDetailRepository;
            this.productRepository = productRepository;
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
                        cartNew.FeeMount = ((product.PercentDiscount * product.Price) / 100) * Quantity;
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
                var cartDetail = cartDetailRepository.GetFirstOrDefaultAsync(x => x.CartId == cart.Id && x.ProductAttributeId == product.Id &&
                x.ProductId == ProductId);
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
                            cart.FeeMount += ((product.PercentDiscount * product.Price) / 100) * Quantity;
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
                            cart.FeeMount += ((product.PercentDiscount * product.Price) / 100) * Quantity;
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

        public async Task<bool> DeleteCart(Guid id)
        {
            try
            {
                var cartDetail = cartDetailRepository.GetById(id);
                await cartDetailRepository.DeleteAsync(cartDetail);
                var cart = cartRepository.GetById(cartDetail.CartId);
                var product = productRepository.GetById(cartDetail.ProductId.Value);

                var listCartDetail = cartDetailRepository.FindBy(x => x.CartId == cart.Id).ToList();
                if (listCartDetail.Count == 0)
                {
                    await cartRepository.DeleteAsync(cart);
                }

                var cartDetails = await cartRepository.GetListCartDetailById(cart.Id);

                decimal total = 0;
                decimal feeMount = 0;
                foreach (var item in cartDetails)
                {
                    total += item.Price * item.Quantity;
                    feeMount = ((product.PercentDiscount.Value * item.Price) / 100) * item.Quantity;
                }
                cart.TotalPrice = total;
                cart.FeeMount = feeMount;
                await cartRepository.UpdateAsync(cart);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<CartDetailViewModel>> GetAllProductCart(Guid UserId)
        {
            return await cartRepository.GetAllProductCart(UserId);
        }

        public async Task<List<CartViewModel>> GetListCart()
        {
            return await cartRepository.GetListCart();
        }

        public async Task<List<CartDetail>> GetListCartDetailById(Guid cartId)
        {
            return await cartRepository.GetListCartDetailById(cartId);
        }

        public async Task<List<CartDetailViewModel>> GetListCartDetailViewModelById(Guid cartId)
        {
            return await cartRepository.GetListCartDetailViewModelById(cartId);
        }
    }
}
