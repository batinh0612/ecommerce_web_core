#pragma checksum "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eac92f5751a6d2aad6faea1eba30f1300aaa6518"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manufacture_Index), @"mvc.1.0.view", @"/Views/Manufacture/Index.cshtml")]
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
#nullable restore
#line 1 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
using Ecommerce.Domain.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eac92f5751a6d2aad6faea1eba30f1300aaa6518", @"/Views/Manufacture/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0aa8b5ddcd2160cc6f2f80e1dac130565e22477", @"/Views/_ViewImports.cshtml")]
    public class Views_Manufacture_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Manufacture>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
  
    ViewData["Title"] = "Nhà sản xuất";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("DataTable", async() => {
                WriteLiteral("\r\n    <!-- DataTables -->\r\n    <link rel=\"stylesheet\" href=\"/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css\">\r\n    <link rel=\"stylesheet\" href=\"/plugins/datatables-responsive/css/responsive.bootstrap4.min.css\">\r\n");
            }
            );
            WriteLiteral(@"
<style>
    .btn-active:hover {
        color: white !important;
    }

    .btn-action {
        line-height: 1 !important;
    }
</style>

<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Nhà sản xuất</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eac92f5751a6d2aad6faea1eba30f1300aaa65185671", async() => {
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
                    <li class=""breadcrumb-item active"">Nhà sản xuất</li>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eac92f5751a6d2aad6faea1eba30f1300aaa65187377", async() => {
                WriteLiteral("Thêm mới");
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
            WriteLiteral("\r\n            </div>\r\n            <!-- /.card-header -->\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 48 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                 if (@ViewBag.Success != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div id=\"msgSuccess\" class=\"alert alert-success\" role=\"alert\">\r\n                        ");
#nullable restore
#line 51 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                   Write(ViewBag.Success);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 53 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table id=""example1"" class=""table table-bordered table-striped"">
                    <thead>
                        <tr>
                            <th>Mã sản phẩm</th>
                            <th>Tên NCC</th>
                            <th>Điện thoại</th>
                            <th>Email</th>
                            <th>Fax</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id=""content_tbody"">
");
#nullable restore
#line 66 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 69 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 70 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                               Write(item.CodeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 71 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                               Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 72 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 73 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                               Write(item.Fax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 75 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                               Write(Html.ActionLink("Sửa", "Edit", new { id = item.Id }, new { @class = "btn btn-primary btn-action" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 76 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                               Write(Html.ActionLink("Xem chi tiết", "Details", new { id = item.Id }, new { @class = "btn btn-info btn-action" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <a href=\"#\" data-id=\"");
#nullable restore
#line 77 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                                                    Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-danger btn-action btn-delete\">Xoá</a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 80 "D:\EcommerceWebCore\Ecommerce.Admin\Views\Manufacture\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n            <!-- /.card-body -->\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/plugins/datatables/jquery.dataTables.min.js""></script>
    <script src=""/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
    <script src=""/plugins/datatables-responsive/js/dataTables.responsive.min.js""></script>
    <script src=""/plugins/datatables-responsive/js/responsive.bootstrap4.min.js""></script>

    <script src=""/js/bootbox.min.js""></script>
    <script src=""/js/controller/manufactureController.js""></script>
    <script>
        setTimeout(function () {
            $(""#msgSuccess"").fadeOut();
        }, 3000);

        $(function () {
            $(""#example1"").DataTable({
                ""paging"": true,
                ""lengthChange"": true,
                ""searching"": true,
                ""ordering"": true,
                ""columnDefs"": [
                    { ""targets"": 5, ""orderable"": false }
                ],
                ""info"": true,
                ""autoWidth"": false,
                ""responsive"": true,
                ""language""");
                WriteLiteral(@": {
                    ""info"": ""Hiển thị _START_ đến _END_ trong _TOTAL_ bản ghi"",
                    ""search"": ""Tìm kiếm:"",
                    ""zeroRecords"": ""Không tìm thấy bản ghi nào"",
                    ""infoFiltered"": ""(Tìm kiếm từ _MAX_ bản ghi)"",
                    ""paginate"": {
                        ""first"": ""Đầu"",
                        ""last"": ""Cuối"",
                        ""next"": ""Sau"",
                        ""previous"": ""Trước""
                    },
                    ""lengthMenu"": ""Hiển thị _MENU_ bản ghi"",
                    ""infoEmpty"": ""Hiển thị 0 đến 0 trong 0 bản ghi"",
                    ""emptyTable"": ""Không có dữ liệu trong bảng"",
                },
                ""zeroRecords"": ""Không tìm thấy bản ghi nào"",
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Manufacture>> Html { get; private set; }
    }
}
#pragma warning restore 1591
