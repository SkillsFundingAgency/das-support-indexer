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
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using SFA.DAS.Support.Portal.Web;
    using SFA.DAS.Support.Portal.Web.Models;
    
    #line 1 "..\..\Views\Search\Index.cshtml"
    using SFA.DAS.Support.Shared.SearchIndexModel;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Search/Index.cshtml")]
    public partial class _Views_Search_Index_cshtml : System.Web.Mvc.WebViewPage<SFA.DAS.Support.Portal.Web.ViewModels.SearchResultsViewModel>
    {

#line 162 "..\..\Views\Search\Index.cshtml"
public System.Web.WebPages.HelperResult Pager()
    {
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 163 "..\..\Views\Search\Index.cshtml"
     



#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <div");

WriteLiteralTo(__razor_helper_writer, " class=\"pagination\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n\r\n");


#line 167 "..\..\Views\Search\Index.cshtml"
            

#line default
#line hidden

#line 167 "..\..\Views\Search\Index.cshtml"
             if (Model.Page > 1)
            {
                

#line default
#line hidden

#line 169 "..\..\Views\Search\Index.cshtml"
WriteTo(__razor_helper_writer, Html.ActionLink("< Prev", "Index", new { Model.SearchTerm, Page = Model.Page - 1, SearchType = Model.SearchType }, new { @class = "previous" }));


#line default
#line hidden

#line 169 "..\..\Views\Search\Index.cshtml"
                                                                                                                                                                

            }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 173 "..\..\Views\Search\Index.cshtml"
            

#line default
#line hidden

#line 173 "..\..\Views\Search\Index.cshtml"
             if (Model.Page != Model.LastPage)
            {
                

#line default
#line hidden

#line 175 "..\..\Views\Search\Index.cshtml"
WriteTo(__razor_helper_writer, Html.ActionLink("Next >", "Index", new { Model.SearchTerm, Page = Model.Page + 1 , SearchType = Model.SearchType}, new { @class = "next" }));


#line default
#line hidden

#line 175 "..\..\Views\Search\Index.cshtml"
                                                                                                                                                            
            }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n");


#line 178 "..\..\Views\Search\Index.cshtml"
            

#line default
#line hidden

#line 178 "..\..\Views\Search\Index.cshtml"
             if (Model.Page != 1 && Model.LastPage != 1)
            {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                <span>Page ");


#line 180 "..\..\Views\Search\Index.cshtml"
WriteTo(__razor_helper_writer, Model.Page);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, " of ");


#line 180 "..\..\Views\Search\Index.cshtml"
            WriteTo(__razor_helper_writer, Model.LastPage);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span>\r\n");


#line 181 "..\..\Views\Search\Index.cshtml"
            }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n        </div>\r\n");


#line 184 "..\..\Views\Search\Index.cshtml"



#line default
#line hidden
});

#line 185 "..\..\Views\Search\Index.cshtml"
}
#line default
#line hidden

        public _Views_Search_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Search\Index.cshtml"
  
    /**/

    ViewBag.currentSection = "search";
    ViewBag.currentPage = "users";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<style>\r\n    .form-label {\r\n        display: inline-block !important;\r\n    }\r" +
"\n\r\n    .sub-nav{\r\n        border: none !important;\r\n    }\r\n\r\n</style>\r\n\r\n<div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n\r\n        <h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">Search</h1>\r\n");

            
            #line 25 "..\..\Views\Search\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Search\Index.cshtml"
         using (Html.BeginForm("Index", "Search", FormMethod.Get, new { accept_charset = "utf-8", @class = "search-field", role = "search" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"search-input\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" for=\"search-main\"");

WriteLiteral(">\r\n                </label>\r\n");

WriteLiteral("                ");

            
            #line 30 "..\..\Views\Search\Index.cshtml"
           Write(Html.TextBoxFor(m => m.SearchTerm, string.Empty, new { id = "search-main", type = "search", @class = "form-control", placeholder = "Enter a name or email address", required = "required", maxlength = "100" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"Page\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(" />\r\n                <div");

WriteLiteral(" class=\"search-submit\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"\"");

WriteLiteral(">Search</button>\r\n                </div>\r\n            </div>\r\n");

            
            #line 36 "..\..\Views\Search\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                <fieldset>\r\n                    <label");

WriteLiteral(" for=\"UserSearchCategory\"");

WriteLiteral(" class=\"form-label selection-button-radio form-control-1-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 40 "..\..\Views\Search\Index.cshtml"
                   Write(Html.RadioButtonFor(m => m.SearchType, SearchCategory.User, new { id= "UserSearchType" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Users\r\n                    </label>\r\n\r\n                " +
"    <label");

WriteLiteral(" for=\"AccountSearchCategory\"");

WriteLiteral(" class=\"form-label selection-button-radio form-control-1-4\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 45 "..\..\Views\Search\Index.cshtml"
                   Write(Html.RadioButtonFor(m => m.SearchType, SearchCategory.Account, new { id = "AccountSearchType" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        Accounts\r\n                    </label>\r\n               " +
" </fieldset>\r\n            </div>\r\n");

            
            #line 50 "..\..\Views\Search\Index.cshtml"

        }

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n");

            
            #line 59 "..\..\Views\Search\Index.cshtml"
 if (Model.AccountSearchResults != null && Model.SearchType == SearchCategory.Account)
{

            
            #line default
            #line hidden
WriteLiteral("    <br />\r\n");

WriteLiteral("    <br />\r\n");

            
            #line 63 "..\..\Views\Search\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n            <h2> Results</h2>\r\n            <p>  ");

            
            #line 67 "..\..\Views\Search\Index.cshtml"
            Write(Model.TotalAccountSearchItems);

            
            #line default
            #line hidden
WriteLiteral(" accounts found</p>\r\n        </div>\r\n    </div>\r\n");

            
            #line 70 "..\..\Views\Search\Index.cshtml"


    if (Model.AccountSearchResults.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("      <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n            <table>\r\n                <tr>\r\n                    <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Account</th>\r\n                    <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Account ID</th>\r\n                    <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral("></th>\r\n                </tr>\r\n");

            
            #line 83 "..\..\Views\Search\Index.cshtml"
                
            
            #line default
            #line hidden
            
            #line 83 "..\..\Views\Search\Index.cshtml"
                 foreach (var account in Model.AccountSearchResults)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td>\r\n");

WriteLiteral("                            ");

            
            #line 87 "..\..\Views\Search\Index.cshtml"
                       Write(account.Account);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");

WriteLiteral("                            ");

            
            #line 90 "..\..\Views\Search\Index.cshtml"
                       Write(account.AccountID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");

WriteLiteral("                            ");

            
            #line 93 "..\..\Views\Search\Index.cshtml"
                       Write(Html.ActionLink("view", "Index", "Resource", new { key = "account", id = account.AccountID }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");

            
            #line 96 "..\..\Views\Search\Index.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </table>\r\n\r\n\r\n");

WriteLiteral("            ");

            
            #line 100 "..\..\Views\Search\Index.cshtml"
       Write(Pager());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        </div>\r\n\r\n    </div>\r\n");

            
            #line 105 "..\..\Views\Search\Index.cshtml"
    }


}
else if (Model.UserSearchResults != null && Model.SearchType == SearchCategory.User)
{

            
            #line default
            #line hidden
WriteLiteral("    <br />\r\n");

WriteLiteral("    <br />\r\n");

            
            #line 113 "..\..\Views\Search\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n            <h2> Results</h2>\r\n            <p>  ");

            
            #line 117 "..\..\Views\Search\Index.cshtml"
            Write(Model.TotalUserSearchItems);

            
            #line default
            #line hidden
WriteLiteral(" users found</p>\r\n        </div>\r\n    </div>\r\n");

            
            #line 120 "..\..\Views\Search\Index.cshtml"

    if (Model.UserSearchResults.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("     <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n\r\n        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n            <table>\r\n                <tr>\r\n                    <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Name</th>\r\n                    <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Email</th>\r\n                    <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Status</th>\r\n                    <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral("></th>\r\n                </tr>\r\n");

            
            #line 133 "..\..\Views\Search\Index.cshtml"
                
            
            #line default
            #line hidden
            
            #line 133 "..\..\Views\Search\Index.cshtml"
                 foreach (var user in Model.UserSearchResults)
                {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 137 "..\..\Views\Search\Index.cshtml"
                   Write(user.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 140 "..\..\Views\Search\Index.cshtml"
                   Write(user.Email);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 143 "..\..\Views\Search\Index.cshtml"
                   Write(user.Status);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 146 "..\..\Views\Search\Index.cshtml"
                   Write(Html.ActionLink("view", "Index", "Resource", new { key="user", id = user.Id }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");

            
            #line 149 "..\..\Views\Search\Index.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </table>\r\n\r\n\r\n");

WriteLiteral("            ");

            
            #line 153 "..\..\Views\Search\Index.cshtml"
       Write(Pager());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n        </div>\r\n\r\n    </div>\r\n");

            
            #line 158 "..\..\Views\Search\Index.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
