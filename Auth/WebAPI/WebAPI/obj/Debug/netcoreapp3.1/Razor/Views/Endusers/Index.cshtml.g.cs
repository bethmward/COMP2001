#pragma checksum "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a4dcd9aef14c901f14f46b8874c802e605d9cfa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Endusers_Index), @"mvc.1.0.view", @"/Views/Endusers/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a4dcd9aef14c901f14f46b8874c802e605d9cfa", @"/Views/Endusers/Index.cshtml")]
    public class Views_Endusers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebAPI.Models.Enduser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserFName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserLName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UserEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserFName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserLName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 978, "\"", 1005, 1);
#nullable restore
#line 40 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
WriteAttributeValue("", 993, item.UserId, 993, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1058, "\"", 1085, 1);
#nullable restore
#line 41 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
WriteAttributeValue("", 1073, item.UserId, 1073, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1140, "\"", 1167, 1);
#nullable restore
#line 42 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
WriteAttributeValue("", 1155, item.UserId, 1155, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\bward\Y2S1\COMP2001\Coursework\WebAPI\WebAPI\Views\Endusers\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebAPI.Models.Enduser>> Html { get; private set; }
    }
}
#pragma warning restore 1591
