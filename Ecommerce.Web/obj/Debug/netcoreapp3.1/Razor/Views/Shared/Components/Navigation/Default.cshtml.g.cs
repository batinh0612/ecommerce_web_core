#pragma checksum "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\Components\Navigation\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26133413baa7e22d4efc5aeedeb7a6a8f8c22ffa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Navigation_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Navigation/Default.cshtml")]
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
#line 1 "D:\EcommerceWebCore\Ecommerce.Web\Views\_ViewImports.cshtml"
using Ecommerce.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\EcommerceWebCore\Ecommerce.Web\Views\_ViewImports.cshtml"
using Ecommerce.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26133413baa7e22d4efc5aeedeb7a6a8f8c22ffa", @"/Views/Shared/Components/Navigation/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f58ca17a8b871dad742f7b6c821f1ef102e04ea7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Navigation_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex justify-content-between"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Start Header Area -->
<header class=""header_area sticky-header"">
    <div class=""main_menu"">
        <nav class=""navbar navbar-expand-lg navbar-light main_box"">
            <div class=""container"">
                <!-- Brand and toggle get grouped for better mobile display -->
                <a class=""navbar-brand logo_h"" href=""/""><img src=""/img/logo.png""");
            BeginWriteAttribute("alt", " alt=\"", 362, "\"", 368, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a>
                <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarSupportedContent""
                        aria-controls=""navbarSupportedContent"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                    <span class=""icon-bar""></span>
                    <span class=""icon-bar""></span>
                    <span class=""icon-bar""></span>
                </button>
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class=""collapse navbar-collapse offset"" id=""navbarSupportedContent"">
                    <ul class=""nav navbar-nav menu_nav ml-auto"">
                        <li class=""nav-item active""><a class=""nav-link"" href=""/"">Home</a></li>
                        <li class=""nav-item submenu dropdown"">
                            <a href=""#"" class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-haspopup=""true""
                               aria-expanded=""false"">Shop</a>
        ");
            WriteLiteral(@"                    <ul class=""dropdown-menu"">
                                <li class=""nav-item""><a class=""nav-link"" href=""/Category/Index"">Shop Category</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""/Product/Details"">Product Details</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""/Product/Checkout"">Product Checkout</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""/Cart/Index"">Shopping Cart</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""/Cart/Confirm"">Confirmation</a></li>
                            </ul>
                        </li>
                        <li class=""nav-item submenu dropdown"">
                            <a href=""#"" class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-haspopup=""true""
                               aria-expanded=""false"">Blog</a>
                            <ul class=""dropdown-menu"">
      ");
            WriteLiteral(@"                          <li class=""nav-item""><a class=""nav-link"" href=""/Blog/Index"">Blog</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""/Blog/Details"">Blog Details</a></li>
                            </ul>
                        </li>
                        <li class=""nav-item submenu dropdown"">
                            <a href=""#"" class=""nav-link dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-haspopup=""true""
                               aria-expanded=""false"">Pages</a>
                            <ul class=""dropdown-menu"">
                                <li class=""nav-item""><a class=""nav-link"" href=""/Login/Index"">Login</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""tracking.html"">Tracking</a></li>
                                <li class=""nav-item""><a class=""nav-link"" href=""elements.html"">Elements</a></li>
                            </ul>
                        </li>
                        <li class=""n");
            WriteLiteral(@"av-item""><a class=""nav-link"" href=""/Contact/Index"">Contact</a></li>
                    </ul>
                    <ul class=""nav navbar-nav navbar-right"">
                        <li class=""nav-item""><a href=""#"" class=""cart""><span class=""ti-bag""></span></a></li>
                        <li class=""nav-item"">
                            <button class=""search""><span class=""lnr lnr-magnifier"" id=""search""></span></button>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>
    <div class=""search_input"" id=""search_input_box"">
        <div class=""container"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26133413baa7e22d4efc5aeedeb7a6a8f8c22ffa8147", async() => {
                WriteLiteral(@"
                <input type=""text"" class=""form-control"" id=""search_input"" placeholder=""Search Here"">
                <button type=""submit"" class=""btn""></button>
                <span class=""lnr lnr-cross"" id=""close_search"" title=""Close Search""></span>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n    </div>\n</header>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        //$("".submenu ul li"").click(function () {
        //    $("".submenu ul li"").removeClass(""active"");
        //    $(this).addClass(""active"");
        //});

        //$('.dropdown-menu').on('click', 'li', function () {
        //    $('.dropdown-menu li').removeClass('active');
        //    $(this).addClass('active');
        //});

        $(document).ready(function () {
            $('.dropdown-menu li a').click(function (e) {

                $('.dropdown-menu li a').removeClass('active');

                var $parent = $(this);
                if (!$parent.hasClass('active')) {
                    $parent.addClass('active');
                }
                e.preventDefault();
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591