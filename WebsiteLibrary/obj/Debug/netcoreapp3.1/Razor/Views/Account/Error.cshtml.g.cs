#pragma checksum "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Account/Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4dafe78faa70a60e6d3a871b1bbca5f25d5a0c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Error), @"mvc.1.0.view", @"/Views/Account/Error.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4dafe78faa70a60e6d3a871b1bbca5f25d5a0c1", @"/Views/Account/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43fc36a6d20eb61c1538a72a59d31ade0c2e713b", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Account/Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1 class=\"text-danger\">Error.</h1>\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\n\n");
#nullable restore
#line 9 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Account/Error.cshtml"
 if (Model.ShowRequestId)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\n        <strong>Request ID:</strong> <code>");
#nullable restore
#line 12 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Account/Error.cshtml"
                                      Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\n    </p>\n");
#nullable restore
#line 14 "/Users/admin/Desktop/Code/MVC/WebsiteLibrary/WebsiteLibrary/Views/Account/Error.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
