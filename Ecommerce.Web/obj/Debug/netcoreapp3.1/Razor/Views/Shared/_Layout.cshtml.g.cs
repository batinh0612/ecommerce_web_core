#pragma checksum "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f56b081bbc55da9149fe9df567820ef44582c8f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f56b081bbc55da9149fe9df567820ef44582c8f3", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f58ca17a8b871dad742f7b6c821f1ef102e04ea7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f56b081bbc55da9149fe9df567820ef44582c8f33216", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
#nullable restore
#line 8 "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n\r\n");
                WriteLiteral(@"    <link rel=""stylesheet"" href=""/css/linearicons.css"">
    <link rel=""stylesheet"" href=""/css/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""/css/themify-icons.css"">
    <link rel=""stylesheet"" href=""/css/bootstrap.css"">
    <link rel=""stylesheet"" href=""/css/owl.carousel.css"">
    <link rel=""stylesheet"" href=""/css/nice-select.css"">
    <link rel=""stylesheet"" href=""/css/nouislider.min.css"">
    <link rel=""stylesheet"" href=""/css/ion.rangeSlider.css"" />
    <link rel=""stylesheet"" href=""/css/ion.rangeSlider.skinFlat.css"" />
    <link rel=""stylesheet"" href=""/css/magnific-popup.css"">
    <link rel=""stylesheet"" href=""/css/main.css"">

    ");
#nullable restore
#line 23 "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml"
Write(RenderSection("Css", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f56b081bbc55da9149fe9df567820ef44582c8f35505", async() => {
                WriteLiteral("\r\n    <input type=\"hidden\" id=\"hiddenBaseAddress\"");
                BeginWriteAttribute("value", " value=\"", 1090, "\"", 1121, 1);
#nullable restore
#line 26 "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1098, _config["BaseAddress"], 1098, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    ");
#nullable restore
#line 27 "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml"
Write(await Component.InvokeAsync("Navigation"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <!-- End Header Area -->\r\n    ");
#nullable restore
#line 29 "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <!-- End related-product Area -->\r\n    <!-- start footer Area -->\r\n    ");
#nullable restore
#line 32 "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml"
Write(await Component.InvokeAsync("Footer"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
    <!-- End footer Area -->

    <script src=""/js/vendor/jquery-2.2.4.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"" integrity=""sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4""
            crossorigin=""anonymous""></script>
    <script src=""/js/vendor/bootstrap.min.js""></script>
    <script src=""/js/jquery.ajaxchimp.min.js""></script>
    <script src=""/js/jquery.nice-select.min.js""></script>
    <script src=""/js/jquery.sticky.js""></script>
    <script src=""/js/nouislider.min.js""></script>
    <script src=""/js/countdown.js""></script>
    <script src=""/js/jquery.magnific-popup.min.js""></script>
    <script src=""/js/owl.carousel.min.js""></script>
    <!--gmaps Js-->
    <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyCjCGmQ0Uq4exrzdcL6rvxywDDOvfAu6eE""></script>
    <script src=""/js/gmaps.min.js""></script>
    <script src=""/js/main.js""></script>
");
                WriteLiteral("\r\n    ");
#nullable restore
#line 52 "D:\EcommerceWebCore\Ecommerce.Web\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.Extensions.Configuration.IConfiguration _config { get; private set; }
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
