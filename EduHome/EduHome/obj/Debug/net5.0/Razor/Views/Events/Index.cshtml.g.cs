#pragma checksum "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d898670bd508201ad228be936c5a546119c95293"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Events_Index), @"mvc.1.0.view", @"/Views/Events/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d898670bd508201ad228be936c5a546119c95293", @"/Views/Events/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b12595893c504d51562e64b077b5eee4604670a3", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Events_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("event"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<!-- Banner Area Start -->
<div class=""banner-area-wrapper"">
    <div class=""banner-area text-center"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""banner-content-wrapper"">
                        <div class=""banner-content"">
                            <h2>event</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Banner Area End -->
<!-- Event Start -->
<div class=""event-area three text-center pt-150 pb-150"">
    <div class=""container"">
        <div class=""row"">
");
#nullable restore
#line 22 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
             foreach(Event events in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4 col-sm-6 col-xs-12\">\r\n                    <div class=\"single-event mb-60\">\r\n                        <div class=\"event-img\">\r\n                            <a href=\"event-details.html\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d898670bd508201ad228be936c5a546119c952935022", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 992, "~/img/event/", 992, 12, true);
#nullable restore
#line 28 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
AddHtmlAttributeValue("", 1004, events.Image, 1004, 13, false);

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
            WriteLiteral(@"
                                <div class=""course-hover"">
                                    <i class=""fa fa-link""></i>
                                </div>
                            </a>
                            <div class=""event-date"">
                                <h3>");
#nullable restore
#line 34 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
                               Write(events.CreatedTime.ToString("dd MMMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"event-content text-left\">\r\n                            <h4><a href=\"event-details.html\">");
#nullable restore
#line 38 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
                                                        Write(events.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                            <ul>\r\n                                <li><span>time:</span> ");
#nullable restore
#line 40 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
                                                  Write(events.StartTime.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 40 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
                                                                                          Write(events.EndTime.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                                <li><span>venue</span> ");
#nullable restore
#line 41 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
                                                  Write(events.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                            </ul>
                            <div class=""event-content-right"">
                                <a class=""default-btn"" href=""event-details.html"">join now</a>
                            </div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 49 "C:\Users\Esma\Desktop\EduHomee\EduHome\EduHome\Views\Events\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<!-- Event End -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
