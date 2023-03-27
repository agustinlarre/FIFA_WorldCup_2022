#pragma checksum "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f30a972794333d9fe4255f294b60b6cdc8f49af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Resenia_FiltroPeriodista), @"mvc.1.0.view", @"/Views/Resenia/FiltroPeriodista.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f30a972794333d9fe4255f294b60b6cdc8f49af", @"/Views/Resenia/FiltroPeriodista.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a12284944598984842f5867fb423256b57554e5f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Resenia_FiltroPeriodista : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Dominio.Resenia>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Periodista", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<!--Vista que muestra las reseñas que realizó el periodista que seleccione el operador-->\r\n<h1>Lista de reseñas del periodista ");
#nullable restore
#line 4 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
                               Write(ViewBag.nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 6 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
 if (Model.Count() > 0)
{
    foreach (var resenia in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dl>\r\n            <dt>\r\n                Nombre completo del periodista\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 15 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
           Write(resenia.UnPeriodista.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 15 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
                                        Write(resenia.UnPeriodista.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                Fecha\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 21 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
           Write(resenia.Fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                Partido\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 27 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
           Write(resenia.UnPartido.Seleccion1.UnPais.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" vs ");
#nullable restore
#line 27 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
                                                          Write(resenia.UnPartido.Seleccion2.UnPais.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                Partido de ");
#nullable restore
#line 28 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
                      Write(resenia.UnPartido.GetTipo());

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n");
#nullable restore
#line 29 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
                 if (resenia.UnPartido.GetTipo() == "Grupos")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Nombre del grupo: ");
#nullable restore
#line 31 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
                                Write(resenia.ObtenerGrupoDelPartido(resenia));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 32 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </dd>\r\n            <dt>\r\n                Título reseña\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 38 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
           Write(resenia.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                Contenido reseña\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 44 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
           Write(resenia.Contenido);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n        <hr />\r\n");
#nullable restore
#line 48 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
        }
    }
else
   {

#line default
#line hidden
#nullable disable
            WriteLiteral("      <p><strong>El periodista no ha realizado ninguna reseña</strong></p>\r\n");
#nullable restore
#line 53 "C:\Users\Alex\OneDrive\Documentos\WorkSpace\WorldCup\Obligatorio Web\Views\Resenia\FiltroPeriodista.cshtml"
   }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--Boton para volver a la lista-->\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f30a972794333d9fe4255f294b60b6cdc8f49af9407", async() => {
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
            WriteLiteral("\r\n</div>\r\n\r\n\r\n");
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