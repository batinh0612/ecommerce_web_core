#pragma checksum "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b09e45c17fe4fcb185fb327e6cb94bae16a0219a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\EcommerceWebCore\Ecommerce.Admin\Views\_ViewImports.cshtml"
using Ecommerce.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\EcommerceWebCore\Ecommerce.Admin\Views\_ViewImports.cshtml"
using Ecommerce.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b09e45c17fe4fcb185fb327e6cb94bae16a0219a", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0aa8b5ddcd2160cc6f2f80e1dac130565e22477", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EcommerceCommon.Infrastructure.ViewModel.Product.ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
  
    ViewData["Title"] = "Thông tin người dùng";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Thông tin người dùng</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b09e45c17fe4fcb185fb327e6cb94bae16a0219a5000", async() => {
                WriteLiteral("Trang chủ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                    <li class=""breadcrumb-item active"">Thông tin người dùng</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""card"">
            <div class=""card-header"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b09e45c17fe4fcb185fb327e6cb94bae16a0219a6714", async() => {
                WriteLiteral("Về danh sách");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <!-- /.card-header -->\r\n            <div class=\"card-body\">\r\n                <dl class=\"row\">\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 33 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 36 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 39 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 42 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 45 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Sku));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 48 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Sku));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 51 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.PublicationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 54 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.PublicationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 57 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.PercentDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 60 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.PercentDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 63 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 66 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Model.Price.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 69 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 72 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 75 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.ProductStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 78 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.ProductStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 81 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Views));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 84 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Views));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 87 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Keyword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 90 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Keyword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 93 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 96 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 99 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.ShortDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 102 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.ShortDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 105 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.CountStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 108 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.CountStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 111 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 114 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 117 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Size));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 120 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Size));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 123 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.SupplierName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 126 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.SupplierName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt class=\"col-sm-2\">\r\n                        ");
#nullable restore
#line 129 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.ManufactureName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd class=\"col-sm-10\">\r\n                        ");
#nullable restore
#line 132 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Product\Details.cshtml"
                   Write(Html.DisplayFor(model => model.ManufactureName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n            <!-- /.card-body -->\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EcommerceCommon.Infrastructure.ViewModel.Product.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
