#pragma checksum "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ca6df6a2aafd09c0b340356ce24e72aaa3abb0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplayFullBlogPost), @"mvc.1.0.view", @"/Views/Home/DisplayFullBlogPost.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/DisplayFullBlogPost.cshtml", typeof(AspNetCore.Views_Home_DisplayFullBlogPost))]
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
#line 1 "/Users/TheKing/Projects/Ass2/Ass2/Views/_ViewImports.cshtml"
using Ass2;

#line default
#line hidden
#line 2 "/Users/TheKing/Projects/Ass2/Ass2/Views/_ViewImports.cshtml"
using Ass2.Models;

#line default
#line hidden
#line 1 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ca6df6a2aafd09c0b340356ce24e72aaa3abb0b", @"/Views/Home/DisplayFullBlogPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c78bc5074947888a8e62049f687a9898b06e78a1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplayFullBlogPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Ass2.ViewModels.BlogPostViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisplayFullBlogPost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(76, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(110, 208, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h1>Posts</h1>\r\n    <div class=\"jumbotron\" style=\"background-color: aliceblue\">\r\n        <span class=\"glyphicon glyphicon-book\">\r\n            <span>\r\n\r\n                <b>Title ");
            EndContext();
            BeginContext(319, 20, false);
#line 14 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                    Write(Model.BlogPost.Title);

#line default
#line hidden
            EndContext();
            BeginContext(339, 34, true);
            WriteLiteral("</b>\r\n                Written By: ");
            EndContext();
            BeginContext(374, 20, false);
#line 15 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                       Write(Model.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(394, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(396, 19, false);
#line 15 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                                             Write(Model.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(415, 32, true);
            WriteLiteral("<br />\r\n                UserId: ");
            EndContext();
            BeginContext(448, 21, false);
#line 16 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                   Write(Model.BlogPost.UserId);

#line default
#line hidden
            EndContext();
            BeginContext(469, 35, true);
            WriteLiteral("<br />\r\n                Posted On: ");
            EndContext();
            BeginContext(505, 21, false);
#line 17 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                      Write(Model.BlogPost.Posted);

#line default
#line hidden
            EndContext();
            BeginContext(526, 31, true);
            WriteLiteral("<br />\r\n                Email: ");
            EndContext();
            BeginContext(558, 23, false);
#line 18 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                  Write(Model.User.EmailAddress);

#line default
#line hidden
            EndContext();
            BeginContext(581, 59, true);
            WriteLiteral("<br />\r\n            </span>\r\n        </span>\r\n\r\n        <p>");
            EndContext();
            BeginContext(641, 22, false);
#line 22 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
      Write(Model.BlogPost.Content);

#line default
#line hidden
            EndContext();
            BeginContext(663, 202, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <div style=\"width: auto; display: block; border: 1px solid DarkGrey; background-color: ActiveBorder; margin: 10px 0px 10px 0px; padding: 0px 20px 5px 20px; border-radius: 10px;\">\r\n");
            EndContext();
#line 25 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
         if (Model.Comments == null)
        {

            

#line default
#line hidden
#line 28 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
             if (Context.Session.GetString("UserId") != null)
            {

#line default
#line hidden
            BeginContext(994, 64, true);
            WriteLiteral("                < p > No comments, Add a comment here...</ p >\r\n");
            EndContext();
#line 31 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1106, 42, true);
            WriteLiteral("                < p > No comments </ p >\r\n");
            EndContext();
#line 35 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
            }

#line default
#line hidden
#line 35 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
             
        }
        else
        {

#line default
#line hidden
            BeginContext(1199, 31, true);
            WriteLiteral("            <h3>Comments</h3>\r\n");
            EndContext();
#line 40 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
             foreach (var c in Model.Comments)
            {

#line default
#line hidden
            BeginContext(1293, 288, true);
            WriteLiteral(@"                <div style=""width: auto; display: block; border: 1px solid DarkGrey; background-color: LightGrey; margin: 10px 0px 10px 0px; padding: 0px 20px 5px 20px; border-radius: 10px;"">

                    <span class=""glyphicon glyphicon-pencil""></span>
                    <p>");
            EndContext();
            BeginContext(1582, 17, false);
#line 45 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                  Write(c.Comment.Content);

#line default
#line hidden
            EndContext();
            BeginContext(1599, 62, true);
            WriteLiteral("</p>\r\n                    <span>\r\n                        By: ");
            EndContext();
            BeginContext(1662, 8, false);
#line 47 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                       Write(c.Author);

#line default
#line hidden
            EndContext();
            BeginContext(1670, 55, true);
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n");
            EndContext();
#line 50 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
            }

#line default
#line hidden
#line 50 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1751, 16, true);
            WriteLiteral("        <hr />\r\n");
            EndContext();
#line 53 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
         if (Context.Session.GetString("UserId") != null)
        {

#line default
#line hidden
            BeginContext(1837, 94, true);
            WriteLiteral("            <div class=\"form-group\">\r\n                <h5>Add a comment</h5>\r\n                ");
            EndContext();
            BeginContext(1931, 393, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "806c6f63b44c4d7c8fec11543b34fd76", async() => {
                BeginContext(1992, 60, true);
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"BlogPostId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2052, "\"", 2086, 1);
#line 58 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
WriteAttributeValue("", 2060, Model.BlogPost.BlogPostId, 2060, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2087, 230, true);
                WriteLiteral(" />\r\n                    <textarea type=\"text\" name=\"Content\" data-length=\"5000\" class=\"form-control\"></textarea><br />\r\n                    <button class=\"btn btn-large btn-success\" type=\"submit\">Submit</button>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2324, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 63 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"

        }

#line default
#line hidden
            BeginContext(2359, 27, true);
            WriteLiteral("        <div class=\"row\">\r\n");
            EndContext();
#line 66 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
              
                foreach (var item in Model.Photos)
                {

#line default
#line hidden
            BeginContext(2473, 123, true);
            WriteLiteral("                    <div class=\"col-md-6\">\r\n                        <div class=\"thumbnail\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2596, "\"", 2612, 1);
#line 71 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
WriteAttributeValue("", 2603, item.Url, 2603, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2613, 55, true);
            WriteLiteral(" target=\"_blank\">\r\n                                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2668, "\"", 2683, 1);
#line 72 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
WriteAttributeValue("", 2674, item.Url, 2674, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2684, 126, true);
            WriteLiteral(" alt=\"Lights\" style=\"width:100%\">\r\n                                <div class=\"caption\">\r\n                                    ");
            EndContext();
            BeginContext(2811, 27, false);
#line 74 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                               Write(item.FileName.Split('.')[0]);

#line default
#line hidden
            EndContext();
            BeginContext(2838, 136, true);
            WriteLiteral("\r\n                                </div>\r\n                            </a>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 79 "/Users/TheKing/Projects/Ass2/Ass2/Views/Home/DisplayFullBlogPost.cshtml"
                }
            

#line default
#line hidden
            BeginContext(3008, 36, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Ass2.ViewModels.BlogPostViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
