using AutoMapper;
using Ecommerce.Service.Interface;
using Ecommerce.WebAPI.Infrastructure.Wrappers;
using EcommerceCommon.Infrastructure.Dto.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _imapper;

        public CategoriesController(ICategoryService categoryService, IMapper imapper)
        {
            _categoryService = categoryService;
            _imapper = imapper;
        }

        [HttpPost("search-and-paging-category")]
        [AllowAnonymous]
        public async Task<ApiResponse> SearchAndPagingCategory([FromBody] QueryBase<BaseSearch> dto, string languageId)
        {
            try
            {
                var list = await _categoryService.SearchAndPagingCategory(dto, languageId);
                return new ApiResponse($"List category", list, 200);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex, 400);
            }
        }
    }
}
