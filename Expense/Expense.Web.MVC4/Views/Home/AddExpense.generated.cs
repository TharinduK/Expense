﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Expense.Web.MVC4;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/AddExpense.cshtml")]
    public partial class _Views_Home_AddExpense_cshtml : System.Web.Mvc.WebViewPage<Expense.Web.MVC4.ViewModel.ExpenseJournalViewModel>
    {
        public _Views_Home_AddExpense_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Home\AddExpense.cshtml"
  
    ViewBag.Title = "AddExpense";
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>Add Expense</h2>\r\n\r\n");

            
            #line 10 "..\..\Views\Home\AddExpense.cshtml"
 using (Html.BeginForm()) 
{
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Home\AddExpense.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Home\AddExpense.cshtml"
                            
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-horizontal\"");

WriteLiteral(">\r\n        <h4>ExpenseJournalViewModel</h4>\r\n        <hr />\r\n");

WriteLiteral("        ");

            
            #line 17 "..\..\Views\Home\AddExpense.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Views\Home\AddExpense.cshtml"
       Write(Html.LabelFor(model => model.Amount, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.EditorFor(model => model.Amount, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.ValidationMessageFor(model => model.Amount, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 27 "..\..\Views\Home\AddExpense.cshtml"
       Write(Html.LabelFor(model => model.Category, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 29 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.EditorFor(model => model.Category, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 30 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.ValidationMessageFor(model => model.Category, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 35 "..\..\Views\Home\AddExpense.cshtml"
       Write(Html.LabelFor(model => model.ExpneseDate, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 37 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.EditorFor(model => model.ExpneseDate, new { htmlAttributes = new { @class = "form - control input - sm w200 datepicker" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 38 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.ValidationMessageFor(model => model.ExpneseDate, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 43 "..\..\Views\Home\AddExpense.cshtml"
       Write(Html.LabelFor(model => model.Merchant, htmlAttributes: new { @class = "control-label col-md-2" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 45 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.EditorFor(model => model.Merchant, new { htmlAttributes = new { @class = "form-control" } }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 46 "..\..\Views\Home\AddExpense.cshtml"
           Write(Html.ValidationMessageFor(model => model.Merchant, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Add Expense\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");

            
            #line 56 "..\..\Views\Home\AddExpense.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div>\r\n");

WriteLiteral("    ");

            
            #line 59 "..\..\Views\Home\AddExpense.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591