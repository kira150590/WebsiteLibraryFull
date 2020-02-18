#pragma checksum "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50e6c85b5ef1170e05d713dbecfe5350c3bb407a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_CreateBook), @"mvc.1.0.view", @"/Views/Book/CreateBook.cshtml")]
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
#line 1 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/_ViewImports.cshtml"
using WebsiteLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/_ViewImports.cshtml"
using WebsiteLibrary.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/_ViewImports.cshtml"
using WebsiteLibrary.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50e6c85b5ef1170e05d713dbecfe5350c3bb407a", @"/Views/Book/CreateBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43fc36a6d20eb61c1538a72a59d31ade0c2e713b", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_CreateBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreateBookViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style>\r\n\r\n        div {\r\n            font-size: 16px;\r\n            color: #007bff;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>$(document).ready(function () {\r\n            $(imageUpload).on(\'change\', function () {\r\n                var fileName = $(this).val().split(\"\\\\\").pop();\r\n                $(this).next(\'\')\r\n            })\r\n        });</script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 24 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
 using (Html.BeginForm("createbook", "book", FormMethod.Post, new { @class = "col-md-4", enctype = "multipart/form-data" }))
{
    Html.AntiForgeryToken();
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
Write(Html.ValidationSummary(false));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <!--Gọi lại nhãn ở ViewModel hiển thị tên-->\r\n        ");
#nullable restore
#line 30 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.LabelFor(x => x.NameOfBook));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 31 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.TextBoxFor(x => x.NameOfBook, new { placeholder = "", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <!--Hiển thị lỗi khi k nhập đúng-->\r\n        ");
#nullable restore
#line 33 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.ValidationMessageFor(x => x.NameOfBook));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 36 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.LabelFor(x => x.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 37 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.TextBoxFor(x => x.Author, new { placeholder = "", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 38 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.ValidationMessageFor(x => x.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 41 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.LabelFor(x => x.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 42 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.DropDownListFor(x => x.CategoryId, (IEnumerable<SelectListItem>)ViewBag.Categories, "Danh Mục", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 43 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.ValidationMessageFor(x => x.CategoryId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 46 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.LabelFor(x => x.YearOfPrint));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 47 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.TextBoxFor(x => x.YearOfPrint, new { placeholder = "", @class = "form-control", type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 48 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.ValidationMessageFor(x => x.YearOfPrint));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 51 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.LabelFor(x => x.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 52 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.TextBoxFor(x => x.Quantity, new { placeholder = "", @class = "form-control", type = "number" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 53 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.ValidationMessageFor(x => x.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 56 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.LabelFor(x => x.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 57 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.TextBoxFor(x => x.Code, new { placeholder = "", @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 58 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.ValidationMessageFor(x => x.Code));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div id=\"imageUpload\" class=\"form-group\">\r\n        ");
#nullable restore
#line 61 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
   Write(Html.LabelFor(x => x.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <input type=""file"" name=""Image"" />
    </div>
    <div class=""form-group"">(Có dấu * vui lòng điền đầy đủ thông tin)</div>
    <button type=""submit"" class=""btn btn-primary"">Tạo Mới</button>
    <button action=""/book/books"" type=""submit"" class=""btn btn-primary"" style=""position: relative; right: -30px;"">Trở Về</button>
");
#nullable restore
#line 67 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Book/CreateBook.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreateBookViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591