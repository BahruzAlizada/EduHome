#pragma checksum "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Shared\Components\Blog\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49cfe8a780c3c4eaea0c3688c47c7a3408ca3795"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Blog_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Blog/Default.cshtml")]
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
#line 1 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.Models.HomeVM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\_ViewImports.cshtml"
using EduHome.ViewsModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49cfe8a780c3c4eaea0c3688c47c7a3408ca3795", @"/Views/Shared/Components/Blog/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b12595893c504d51562e64b077b5eee4604670a3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Blog_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blog>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("blog"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n  \r\n");
#nullable restore
#line 4 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Shared\Components\Blog\Default.cshtml"
     foreach (Blog blog in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-4 col-sm-6 col-xs-12\">\r\n                <div class=\"single-blog\">\r\n                    <div class=\"blog-img\">\r\n                        <a href=\"blog-details.html\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "49cfe8a780c3c4eaea0c3688c47c7a3408ca37954372", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 271, "~/img/blog/", 271, 11, true);
#nullable restore
#line 9 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Shared\Components\Blog\Default.cshtml"
AddHtmlAttributeValue("", 282, blog.Image, 282, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</a>
                        <div class=""blog-hover"">
                            <a href=""blog-details.html""><i class=""fa fa-link""></i></a>
                        </div>
                    </div>
                    <div class=""blog-content"">
                        <div class=""blog-top"">
                            <p>");
#nullable restore
#line 16 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Shared\Components\Blog\Default.cshtml"
                          Write(blog.By);

#line default
#line hidden
#nullable disable
            WriteLiteral("  /  ");
#nullable restore
#line 16 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Shared\Components\Blog\Default.cshtml"
                                       Write(blog.CreatedTime.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("  /  <i class=\"fa fa-comments-o\"></i> 4</p>\r\n                        </div>\r\n                        <div class=\"blog-bottom\">\r\n                            <h2><a href=\"blog-details.html\">");
#nullable restore
#line 19 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Shared\Components\Blog\Default.cshtml"
                                                       Write(blog.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a></h2>\r\n                            <a href=\"blog-details.html\">read more</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 25 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Shared\Components\Blog\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n         ");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blog>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
