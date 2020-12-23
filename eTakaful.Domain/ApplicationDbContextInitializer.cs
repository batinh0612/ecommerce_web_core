using System;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Domain
{
    public class ApplicationDbContextInitializer : IApplicationDbContextInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }

        public async Task Seed()
        {
            await SeedLanguageId(_context);

            await SeedCategory(_context);
            await SeedCategoryTranslation(_context);

            await SeedSupplier(_context);
            await SeedManufature(_context);
            
            await SeedProduct(_context);
            await SeedProductTranslation(_context);
            await SeedProducSize(_context);
            await SeedProducColor(_context);
            await SeedProductAttribute(_context);

            await SeedProductInCategory(_context);

            await SeedCustomer(_context);

            await SeedOrder(_context);
            await SeedOrderDetail(_context);

            await SeedUser(_context);
        }

        #region SeedData
        private async Task SeedSupplier(ApplicationDbContext context)
        {
            if (!context.Suppliers.Any())
            {
                context.Suppliers.Add(new Supplier { 
                    Name = "Tiki",
                    CodeName = "Tiki",
                    Phone = "0968684457",
                    Email = "tiki@gmail.com",
                    Fax = "Lorem Ipsum is simply"
                });

                context.Suppliers.Add(new Supplier
                {
                    Name = "Lazada",
                    CodeName = "CNXKMKCX",
                    Phone = "0968684457",
                    Email = "lazada@gmail.com",
                    Fax = "Lorem Ipsum is simply"
                });

                context.Suppliers.Add(new Supplier
                {
                    Name = "Shopee",
                    CodeName = "MGKFXM",
                    Phone = "0968684457",
                    Email = "shopee@gmail.com",
                    Fax = "Lorem Ipsum is simply"
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedLanguageId(ApplicationDbContext context)
        {
            if (!context.Languages.Any())
            {
                context.Languages.Add(new Language
                {
                    Id = "vi",
                    Name = "Tiếng Việt",
                    IsDefault = true
                });

                context.Languages.Add(new Language
                {
                    Id = "en",
                    Name = "Tiếng Anh",
                    IsDefault = false
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedProducSize(ApplicationDbContext context)
        {
            if (!context.ProductSizes.Any())
            {
                context.ProductSizes.Add(new ProductSize { 
                    Name = "29"
                });

                context.ProductSizes.Add(new ProductSize
                {
                    Name = "30"
                });

                context.ProductSizes.Add(new ProductSize
                {
                    Name = "31"
                });

                context.ProductSizes.Add(new ProductSize
                {
                    Name = "32"
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedProducColor(ApplicationDbContext context)
        {
            if (!context.ProductColors.Any())
            {
                context.ProductColors.Add(new ProductColor { 
                    Name = "Đen"
                });

                context.ProductColors.Add(new ProductColor
                {
                    Name = "Trắng"
                });

                context.ProductColors.Add(new ProductColor
                {
                    Name = "Xám"
                });

                context.ProductColors.Add(new ProductColor
                {
                    Name = "Vàng"
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedProductAttribute(ApplicationDbContext context)
        {
            if (!context.ProductAttributes.Any())
            {
                var product1 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CNMSC11X");
                var product2 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CNMSC11X");
                var product3 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CMXM");
                var product4 = await context.Products.FirstOrDefaultAsync(x => x.Code == "MSCCS");

                var productColor1 = await context.ProductColors.FirstOrDefaultAsync(x => x.Name == "Đen");
                var productColor2 = await context.ProductColors.FirstOrDefaultAsync(x => x.Name == "Trắng");
                var productColor3 = await context.ProductColors.FirstOrDefaultAsync(x => x.Name == "Xám");
                var productColor4 = await context.ProductColors.FirstOrDefaultAsync(x => x.Name == "Vàng");

                var productSize1 = await context.ProductSizes.FirstOrDefaultAsync(x => x.Name == "29");
                var productSize2 = await context.ProductSizes.FirstOrDefaultAsync(x => x.Name == "30");
                var productSize3 = await context.ProductSizes.FirstOrDefaultAsync(x => x.Name == "31");
                var productSize4 = await context.ProductSizes.FirstOrDefaultAsync(x => x.Name == "32");

                context.ProductAttributes.Add(new ProductAttribute { 
                    ProductSizeId = productSize1.Id,
                    ProductColorId = productColor1.Id,
                    ProductId = product1.Id,
                    CountStock = 50
                });

                context.ProductAttributes.Add(new ProductAttribute
                {
                    ProductSizeId = productSize2.Id,
                    ProductColorId = productColor2.Id,
                    ProductId = product2.Id,
                    CountStock = 50
                });

                context.ProductAttributes.Add(new ProductAttribute
                {
                    ProductSizeId = productSize3.Id,
                    ProductColorId = productColor3.Id,
                    ProductId = product3.Id,
                    CountStock = 50
                });

                context.ProductAttributes.Add(new ProductAttribute
                {
                    ProductSizeId = productSize4.Id,
                    ProductColorId = productColor4.Id,
                    ProductId = product4.Id,
                    CountStock = 50
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedProduct(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                var manufature = await context.Manufactures.FirstOrDefaultAsync(x => x.Name == "LG");
                var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Name == "Tiki");

                context.Products.Add(new Product { 
                    SupplierId = supplier.Id,
                    ManufactureId = manufature.Id,
                    Sku = "Sgdk323",
                    CommonStatus = Enums.Status.Active,
                    Views = 100,
                    PublicationDate = DateTime.Now,
                    Code = "CNMSC11X",
                    Price = 1500000,
                    Quantity = 50,
                    PercentDiscount = 10
                });

                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    ManufactureId = manufature.Id,
                    Sku = "czxz",
                    CommonStatus = Enums.Status.Active,
                    Views = 100,
                    PublicationDate = DateTime.Now,
                    Code = "NDKCM",
                    Price = 2000000,
                    Quantity = 30,
                    PercentDiscount = 10
                });

                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    ManufactureId = manufature.Id,
                    Sku = "czxz",
                    CommonStatus = Enums.Status.Active,
                    Views = 100,
                    PublicationDate = DateTime.Now,
                    Code = "CMXM",
                    Price = 1700000,
                    Quantity = 30,
                    PercentDiscount = 10
                });

                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    ManufactureId = manufature.Id,
                    Sku = "gfgvf",
                    CommonStatus = Enums.Status.Active,
                    Views = 50,
                    PublicationDate = DateTime.Now,
                    Code = "MSCCS",
                    Price = 1300000,
                    Quantity = 30,
                    PercentDiscount = 10,
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedProductTranslation(ApplicationDbContext context)
        {
            if (!context.ProductTranslations.Any())
            {
                var product1 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CNMSC11X");
                var product2 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CNMSC11X");
                var product3 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CMXM");
                var product4 = await context.Products.FirstOrDefaultAsync(x => x.Code == "MSCCS");

                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Mô tả ngắn",
                    Description = "Mô tả chi tiết",
                    Name = "Samsung s10",
                    Keyword = "samsung",
                    Details = "Chi tiết sản phẩm",
                    LanguageId = "vi",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product1.Id
                });

                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Mô tả ngắn",
                    Description = "Mô tả chi tiết",
                    Name = "Lg s10",
                    Keyword = "samsung",
                    Details = "Chi tiết sản phẩm",
                    LanguageId = "vi",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product2.Id
                });

                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Mô tả ngắn",
                    Description = "Mô tả chi tiết",
                    Keyword = "samsung",
                    Name = "Oppo",
                    Details = "Chi tiết sản phẩm",
                    LanguageId = "vi",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product3.Id
                });

                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Mô tả ngắn",
                    Description = "Mô tả chi tiết",
                    Keyword = "samsung",
                    Name = "Xiaomi",
                    Details = "Chi tiết sản phẩm",
                    LanguageId = "vi",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product4.Id
                });




                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Short description",
                    Description = "Description",
                    Name = "Samsung s10",
                    Keyword = "samsung",
                    Details = "Detail product",
                    LanguageId = "en",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product1.Id
                });

                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Short description",
                    Description = "Description",
                    Name = "Lg s10",
                    Keyword = "samsung",
                    Details = "Detail product",
                    LanguageId = "en",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product2.Id
                });

                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Short description",
                    Description = "Description",
                    Name = "Samsung s10",
                    Keyword = "samsung",
                    Details = "Detail product",
                    LanguageId = "en",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product3.Id
                });

                context.ProductTranslations.Add(new ProductTranslation
                {
                    ProductStatus = ProductStatusEnum.New,
                    ShortDescription = "Short description",
                    Description = "Description",
                    Name = "Xiaomi",
                    Keyword = "samsung",
                    Details = "Detail product",
                    LanguageId = "en",
                    SeoAlias = "seo",
                    SeoDescription = "description",
                    SeoTitle = "title",
                    ProductId = product4.Id
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedCategory(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { 
                    ParentId = null,
                    IsDisplayHomePage = true,
                    CreatedDate = DateTime.Now,
                    CommonStatus = Status.Active,
                    Sort = 1,
                    IsDeleted = false
                });

                context.Categories.Add(new Category
                {
                    ParentId = null,
                    IsDisplayHomePage = false,
                    CreatedDate = DateTime.Now,
                    CommonStatus = Status.Active,
                    Sort = 2,
                    IsDeleted = false
                });

                await context.SaveChangesAsync();

                var category = await context.Categories.FirstOrDefaultAsync(x => x.IsDisplayHomePage == true);

                context.Categories.Add(new Category
                {
                    ParentId = category.Id,
                    IsDisplayHomePage = true,
                    CreatedDate = DateTime.Now,
                    CommonStatus = Status.Active,
                    Sort = 3,
                    IsDeleted = false
                });

                context.Categories.Add(new Category
                {
                    ParentId = category.Id,
                    IsDisplayHomePage = true,
                    CreatedDate = DateTime.Now,
                    CommonStatus = Status.Active,
                    Sort = 4,
                    IsDeleted = false
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedCategoryTranslation(ApplicationDbContext context)
        {
            if (!context.CategoryTranslations.Any())
            {
                var category1 = await context.Categories.FirstOrDefaultAsync(x => x.Sort == 1);
                var category2 = await context.Categories.FirstOrDefaultAsync(x => x.Sort == 2);
                var category3 = await context.Categories.FirstOrDefaultAsync(x => x.Sort == 3);
                var category4 = await context.Categories.FirstOrDefaultAsync(x => x.Sort == 4);

                context.CategoryTranslations.Add(new CategoryTranslation
                {
                    Name = "Điện lạnh",
                    Description = "Điện lạnh",
                    MetaTitle = "dien-lanh",
                    CategoryId = category1.Id,
                    LanguageId = "vi"
                });

                context.CategoryTranslations.Add(new CategoryTranslation
                {
                    Name = "Dien lanh",
                    Description = "Dien lanh",
                    MetaTitle = "dien-lanh",
                    CategoryId = category2.Id,
                    LanguageId = "en",
                });

                await context.SaveChangesAsync();

                var category = await context.Categories.FirstOrDefaultAsync(x => x.IsDisplayHomePage == true);

                context.CategoryTranslations.Add(new CategoryTranslation
                {
                    Name = "Máy tính bảng",
                    Description = "Máy tính bảng",
                    MetaTitle = "may-tinh-bang",
                    CategoryId = category3.Id,
                    LanguageId = "vi",
                });

                context.CategoryTranslations.Add(new CategoryTranslation
                {
                    Name = "May tinh bang",
                    Description = "May tinh bang",
                    MetaTitle = "may-tinh-bang",
                    CategoryId = category4.Id,
                    LanguageId = "en",
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedOrderDetail(ApplicationDbContext context)
        {
            if (!context.OrderDetails.Any())
            {
                var order = await context.Orders.FirstOrDefaultAsync(x => x.Address == "Số 20, ngõ 192 Lê Trọng Tấn");
                var product = await context.Products.FirstOrDefaultAsync(x => x.Code == "NDKCM");

                context.OrderDetails.Add(new OrderDetail { 
                   Quantity = 1,
                   Price = 11000000,
                   Voucher = null,
                   OrderId = order.Id,
                   ProductId = product.Id
                });

                context.OrderDetails.Add(new OrderDetail
                {
                    Quantity = 1,
                    Price = 2000000,
                    Voucher = null,
                    OrderId = order.Id,
                    ProductId = product.Id
                });
                await context.SaveChangesAsync();
            }
        }

        private async Task SeedCustomer(ApplicationDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.Add(new Customer { 
                    Name = "Nguyễn Bá Tình",
                    Address = "Ngô Nội, Trung Nghĩa, Yên Phong, Bắc Ninh",
                    Phone = "0947282765",
                    CustomerAddresses = null,
                    Email = "batinhypbn@gmail.com"
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedOrder(ApplicationDbContext context)
        {
            if (!context.Orders.Any())
            {
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Email.Equals("batinhypbn@gmail.com"));

                context.Orders.Add(new Order { 
                    PaymentType = Payment.Online,
                    Phone = "0968684457",
                    OrderNumber = 1,
                    OrderStatus = OrderStatusEnum.Shipped,
                    VoucherCode = null,
                    FeeMount = 0,
                    Discount = 0,
                    Address = "Số 20, ngõ 192 Lê Trọng Tấn",
                    Province = "Bắc Ninh",
                    Districts = "Yên Phong",
                    Ward = "Trung Nghĩa",
                    TotalPrice = 13000000,
                    CustomerId = customer.Id
                });

                await context.SaveChangesAsync();
            }
        }

        //private async Task SeedUserProfile(ApplicationDbContext context)
        //{
        //    if (!context.UserProfiles.Any())
        //    {
        //        var user1 = await context.Users.FirstOrDefaultAsync(x => x.Username == "batinh0612");
        //        var user2 = await context.Users.FirstOrDefaultAsync(x => x.Username == "badung0411");
        //        var user3 = await context.Users.FirstOrDefaultAsync(x => x.Username == "thaihoc");
        //        var user4 = await context.Users.FirstOrDefaultAsync(x => x.Username == "minhhieu");
        //        var user5 = await context.Users.FirstOrDefaultAsync(x => x.Username == "trinhha");
        //        var user6 = await context.Users.FirstOrDefaultAsync(x => x.Username == "hoangnam");

        //        context.UserProfiles.Add(new UserProfile {
        //            FirstName = "Nguyễn Bá",
        //            LastName = "Tình",
        //            Address = "Yên Phong - Bắc Ninh",
        //            Avatar = "fdsdjsnf.jpg",
        //            Email = "batinhypbn@gmail.com",
        //            Phone = "0968684457",
        //            UserId = user1.Id
        //        });

        //        context.UserProfiles.Add(new UserProfile
        //        {
        //            FirstName = "Nguyễn Bá",
        //            LastName = "Dũng",
        //            Address = "Yên Phong - Bắc Ninh",
        //            Avatar = "fvcxvcx.jpg",
        //            Email = "badung0411@gmail.com",
        //            Phone = "0397779413",
        //            UserId = user2.Id
        //        });

        //        context.UserProfiles.Add(new UserProfile
        //        {
        //            FirstName = "Nguyễn Minh",
        //            LastName = "Hiếu",
        //            Address = "Yên Phong - Bắc Ninh",
        //            Avatar = "fdsdjsnf.jpg",
        //            Email = "batinhypbn@gmail.com",
        //            Phone = "0968684457",
        //            UserId = user3.Id
        //        });

        //        context.UserProfiles.Add(new UserProfile
        //        {
        //            FirstName = "Nguyễn Thái",
        //            LastName = "Học",
        //            Address = "Yên Phong - Bắc Ninh",
        //            Avatar = "fvcxvcx.jpg",
        //            Email = "badung0411@gmail.com",
        //            Phone = "0397779413",
        //            UserId = user4.Id
        //        });

        //        context.UserProfiles.Add(new UserProfile
        //        {
        //            FirstName = "Lê Hoàng",
        //            LastName = "Nam",
        //            Address = "Yên Phong - Bắc Ninh",
        //            Avatar = "fdsdjsnf.jpg",
        //            Email = "batinhypbn@gmail.com",
        //            Phone = "0968684457",
        //            UserId = user5.Id
        //        });

        //        context.UserProfiles.Add(new UserProfile
        //        {
        //            FirstName = "Nguyễn Trịnh",
        //            LastName = "Hà",
        //            Address = "Yên Phong - Bắc Ninh",
        //            Avatar = "fvcxvcx.jpg",
        //            Email = "badung0411@gmail.com",
        //            Phone = "0397779413",
        //            UserId = user6.Id
        //        });

        //        await context.SaveChangesAsync();
        //    }
        //}

        private async Task SeedUser(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Add(new User { 

                    Username = "batinh0612",
                    PasswordHash = null,
                    PasswordSalt = null,
                    RoleId = null,
                    FirstName = "Nguyễn Bá",
                    LastName = "Tình",
                    Address = "Yên Phong - Bắc Ninh",
                    Avatar = "fdsdjsnf.jpg",
                    Email = "batinhypbn@gmail.com",
                    Phone = "0968684457"
                });

                context.Add(new User
                {
                    Username = "badung0411",
                    PasswordHash = null,
                    PasswordSalt = null,
                    RoleId = null,
                    FirstName = "Nguyễn Bá",
                    LastName = "Dũng",
                    Address = "Yên Phong - Bắc Ninh",
                    Avatar = "fvcxvcx.jpg",
                    Email = "badung0411@gmail.com",
                    Phone = "0397779413"
                });

                context.Add(new User
                {
                    Username = "thaihoc",
                    PasswordHash = null,
                    PasswordSalt = null,
                    RoleId = null,
                    FirstName = "Nguyễn Thái",
                    LastName = "Học",
                    Address = "Yên Phong - Bắc Ninh",
                    Avatar = "fvcxvcx.jpg",
                    Email = "badung0411@gmail.com",
                    Phone = "0397779413"
                });

                context.Add(new User
                {
                    FirstName = "Nguyễn Minh",
                    LastName = "Hiếu",
                    Address = "Yên Phong - Bắc Ninh",
                    Avatar = "fdsdjsnf.jpg",
                    Email = "batinhypbn@gmail.com",
                    Phone = "0968684457",
                    Username = "minhhieu",
                    PasswordHash = null,
                    PasswordSalt = null,
                    RoleId = null
                });

                context.Add(new User
                {
                    Username = "trinhha",
                    PasswordHash = null,
                    PasswordSalt = null,
                    RoleId = null,
                    FirstName = "Nguyễn Trịnh",
                    LastName = "Hà",
                    Address = "Yên Phong - Bắc Ninh",
                    Avatar = "fvcxvcx.jpg",
                    Email = "badung0411@gmail.com",
                    Phone = "0397779413"
                });

                context.Add(new User
                {
                    Username = "hoangnam",
                    PasswordHash = null,
                    PasswordSalt = null,
                    RoleId = null,
                    FirstName = "Lê Hoàng",
                    LastName = "Nam",
                    Address = "Yên Phong - Bắc Ninh",
                    Avatar = "fdsdjsnf.jpg",
                    Email = "batinhypbn@gmail.com",
                    Phone = "0968684457"
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedManufature(ApplicationDbContext context)
        {
            if (!context.Manufactures.Any())
            {
                context.Add(new Manufacture
                {
                    Name = "LG",
                    Phone = "0984236412",
                    Email = "lg@gmail.com",
                    CodeName = "NDS4105D",
                    Fax = "cjdasdad",
                    CommonStatus = Status.Active,
                });

                context.Add(new Manufacture
                {
                    Name = "Samsung",
                    Phone = "0984236412",
                    Email = "samsung@gmail.com",
                    CodeName = "CMXNCX",
                    Fax = "cjdasdad",
                    CommonStatus = Status.Active,
                });

                context.Add(new Manufacture
                {
                    Name = "Canon",
                    Phone = "0984236412",
                    Email = "canon@gmail.com",
                    CodeName = "NFCMXNC",
                    Fax = "cjdasdad",
                    CommonStatus = Status.Active,
                });

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedProductInCategory(ApplicationDbContext context)
        {
            if (!context.ProductInCategories.Any())
            {
                var product1 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CNMSC11X");
                var product2 = await context.Products.FirstOrDefaultAsync(x => x.Code == "NDKCM");
                var product3 = await context.Products.FirstOrDefaultAsync(x => x.Code == "CMXM");
                var product4 = await context.Products.FirstOrDefaultAsync(x => x.Code == "MSCCS");

                var category1 = await context.CategoryTranslations.FirstOrDefaultAsync(x => x.Name == "Máy tính bảng");
                var category2 = await context.CategoryTranslations.FirstOrDefaultAsync(x => x.Name == "Điện lạnh");

                context.ProductInCategories.Add(new ProductInCategory() { 
                    ProductId = product1.Id,
                    CategoryId = category1.CategoryId
                });

                context.ProductInCategories.Add(new ProductInCategory()
                {
                    ProductId = product2.Id,
                    CategoryId = category2.CategoryId
                });

                context.ProductInCategories.Add(new ProductInCategory()
                {
                    ProductId = product3.Id,
                    CategoryId = category1.CategoryId
                });

                context.ProductInCategories.Add(new ProductInCategory()
                {
                    ProductId = product4.Id,
                    CategoryId = category2.CategoryId
                });
            }
        }
        #endregion
    }
}