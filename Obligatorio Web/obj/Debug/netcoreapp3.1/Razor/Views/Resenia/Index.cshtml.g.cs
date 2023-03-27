#pragma checksum "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e62cc719f736821ead72f17079367e4974bc9183"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resenia_Index), @"mvc.1.0.view", @"/Views/Resenia/Index.cshtml")]
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
#line 1 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\_ViewImports.cshtml"
using Obligatorio_Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\_ViewImports.cshtml"
using Obligatorio_Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e62cc719f736821ead72f17079367e4974bc9183", @"/Views/Resenia/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a12284944598984842f5867fb423256b57554e5f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Resenia_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Dominio.Resenia>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n<!--Vista que muestra la lista de reseñas del periodista logueado-->\n<h1>Lista de Resenias</h1>\n\n");
#nullable restore
#line 6 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
 if (ViewBag.ListaVacia)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p><strong>La lista de reseñas se encuentra vacía</strong></p>\n");
#nullable restore
#line 9 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\n        <tr>\n            <th>ID</th>\n            <th>Periodista</th>\n            <th>Fecha</th>\n            <th>Partido</th>\n            <th>Titulo</th>\n            <th>Detalles</th>\n        </tr>\n");
#nullable restore
#line 21 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
         foreach (var r in Model)
        {
            if (r.UnPeriodista == ViewBag.User)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 26 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
                   Write(r.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 27 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
                   Write(r.UnPeriodista.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 28 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
                   Write(r.Fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 29 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
                   Write(r.UnPartido.Seleccion1.UnPais.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <strong>vs</strong> ");
#nullable restore
#line 29 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
                                                                             Write(r.UnPartido.Seleccion2.UnPais.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 30 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
                   Write(r.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 31 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
                   Write(Html.ActionLink("Ver detalles", "Details", new { id = r.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 33 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n");
#nullable restore
#line 36 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!--Botón para volver a la lista de periodistas con sus correspondientes reseñas-->\n    <div>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e62cc719f736821ead72f17079367e4974bc91838026", async() => {
                WriteLiteral("Volver");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Dominio.Resenia>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
