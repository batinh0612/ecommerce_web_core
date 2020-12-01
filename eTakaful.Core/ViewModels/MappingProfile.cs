using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Dto;
using Ecommerce.Service.ViewModels;
using EcommerceCommon.Infrastructure.Dto.Manufacture;
using EcommerceCommon.Infrastructure.Dto.Supplier;
using EcommerceCommon.Infrastructure.Dto.User;
using EcommerceCommon.Infrastructure.ViewModel.Product;
using EcommerceCommon.Infrastructure.ViewModel.Supplier;

namespace Ecommerce.Core.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingEntityToViewModel();
            MappingViewModelToEntity();
        }

        private void MappingEntityToViewModel()
        {
            // case get data
            CreateMap<Category, CategoryVM>();
            //.ForMember(x => x.Description, options => options.MapFrom(x => x.MetaTitle))
            CreateMap<Product, ProductViewModel>();
            CreateMap<User, UserDto>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<User, UserUpdateDto>();
        }

        private void MappingViewModelToEntity()
        {
            // case insert or update
            CreateMap<CategoryDto, Category>();
            CreateMap<UserDto, User>();
            CreateMap<RoleDto, Role>();
            CreateMap<SupplierDto, Supplier>();
            CreateMap<ManufactureDto, Manufacture>();
        }
    }
}