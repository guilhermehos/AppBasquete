#pragma checksum "C:\Users\Vitor\source\repos\AppDemo\Views\Pontos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45348adf2167b5b66aa283a619a0340b08f34e5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pontos_Index), @"mvc.1.0.view", @"/Views/Pontos/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45348adf2167b5b66aa283a619a0340b08f34e5c", @"/Views/Pontos/Index.cshtml")]
    public class Views_Pontos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"pt-br\" data-ng-app=\"app\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45348adf2167b5b66aa283a619a0340b08f34e5c2732", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
    <title>Pontos</title>
    
    <!-- Fonts -->
    <link href=""https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700"" rel=""stylesheet"">
    <!-- Icons -->
    <link");
                BeginWriteAttribute("href", " href=\"", 370, "\"", 427, 1);
#nullable restore
#line 11 "C:\Users\Vitor\source\repos\AppDemo\Views\Pontos\Index.cshtml"
WriteAttributeValue("", 377, Url.Content("~/js/plugins/nucleo/css/nucleo.css"), 377, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 459, "\"", 539, 1);
#nullable restore
#line 12 "C:\Users\Vitor\source\repos\AppDemo\Views\Pontos\Index.cshtml"
WriteAttributeValue("", 466, Url.Content("~/js/plugins/fortawesome/fontawesome-free/css/all.min.css"), 466, 73, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n    <!-- CSS Files -->\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 595, "\"", 648, 1);
#nullable restore
#line 14 "C:\Users\Vitor\source\repos\AppDemo\Views\Pontos\Index.cshtml"
WriteAttributeValue("", 602, Url.Content("~/css/argon-dashboard_.min.css"), 602, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 680, "\"", 727, 1);
#nullable restore
#line 15 "C:\Users\Vitor\source\repos\AppDemo\Views\Pontos\Index.cshtml"
WriteAttributeValue("", 687, Url.Content("~/css/bundle/app.min.css"), 687, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45348adf2167b5b66aa283a619a0340b08f34e5c5747", async() => {
                WriteLiteral("\r\n    <div ui-view id=\"app\"></div>\r\n\r\n    <!-- Core -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 835, "\"", 887, 1);
#nullable restore
#line 22 "C:\Users\Vitor\source\repos\AppDemo\Views\Pontos\Index.cshtml"
WriteAttributeValue("", 841, Url.Content("~/js/bundle/app.general.min.js"), 841, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- Services --> \r\n    <script");
                BeginWriteAttribute("src", " src=\"", 935, "\"", 988, 1);
#nullable restore
#line 24 "C:\Users\Vitor\source\repos\AppDemo\Views\Pontos\Index.cshtml"
WriteAttributeValue("", 941, Url.Content("~/js/bundle/app.services.min.js"), 941, 47, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
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
            WriteLiteral("\r\n</html>");
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