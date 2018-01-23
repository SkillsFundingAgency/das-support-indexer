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

#line 157 "..\..\Views\Search\Index.cshtml"
public System.Web.WebPages.HelperResult Pager()
    {
#line default
#line hidden
return new System.Web.WebPages.HelperResult(__razor_helper_writer => {

#line 158 "..\..\Views\Search\Index.cshtml"
     


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "        <div");

WriteLiteralTo(__razor_helper_writer, " class=\"grid-row\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n            <div");

WriteLiteralTo(__razor_helper_writer, " class=\"column-full\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                <div");

WriteLiteralTo(__razor_helper_writer, " class=\"page-navigation\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n\r\n\r\n\r\n");


#line 165 "..\..\Views\Search\Index.cshtml"
                    

#line default
#line hidden

#line 165 "..\..\Views\Search\Index.cshtml"
                     if (Model.Page > 1)
                    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                        <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 6963), Tuple.Create("\"", 7070)

#line 167 "..\..\Views\Search\Index.cshtml"
, Tuple.Create(Tuple.Create("", 6970), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", new { Model.SearchTerm, Page = Model.Page - 1, SearchType = Model.SearchType })

#line default
#line hidden
, 6970), false)
);

WriteLiteralTo(__razor_helper_writer, " style=\"visibility: visible\"");

WriteLiteralTo(__razor_helper_writer, " class=\"page-navigation__btn prev\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                            <i");

WriteLiteralTo(__razor_helper_writer, " class=\"arrow-button fa fa-angle-left\"");

WriteLiteralTo(__razor_helper_writer, "></i>\r\n                            <span");

WriteLiteralTo(__razor_helper_writer, " class=\"description\"");

WriteLiteralTo(__razor_helper_writer, ">Previous <span");

WriteLiteralTo(__razor_helper_writer, " class=\"hide-mob\"");

WriteLiteralTo(__razor_helper_writer, ">page</span></span>\r\n                            <span");

WriteLiteralTo(__razor_helper_writer, " class=\"counter\"");

WriteLiteralTo(__razor_helper_writer, ">");


#line 170 "..\..\Views\Search\Index.cshtml"
                    WriteTo(__razor_helper_writer, Model.Page);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, " of ");


#line 170 "..\..\Views\Search\Index.cshtml"
                                   WriteTo(__razor_helper_writer, Model.LastPage);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span>\r\n                        </a>\r\n");


#line 172 "..\..\Views\Search\Index.cshtml"
                    }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n\r\n\r\n");


#line 176 "..\..\Views\Search\Index.cshtml"
                    

#line default
#line hidden

#line 176 "..\..\Views\Search\Index.cshtml"
                     if (Model.Page != Model.LastPage)
                    {


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "                        <a");

WriteAttributeTo(__razor_helper_writer, "href", Tuple.Create(" href=\"", 7570), Tuple.Create("\"", 7678)

#line 178 "..\..\Views\Search\Index.cshtml"
, Tuple.Create(Tuple.Create("", 7577), Tuple.Create<System.Object, System.Int32>(Url.Action( "Index", new { Model.SearchTerm, Page = Model.Page + 1, SearchType = Model.SearchType })

#line default
#line hidden
, 7577), false)
);

WriteLiteralTo(__razor_helper_writer, " style=\"visibility: visible\"");

WriteLiteralTo(__razor_helper_writer, " class=\"page-navigation__btn next\"");

WriteLiteralTo(__razor_helper_writer, ">\r\n                            <i");

WriteLiteralTo(__razor_helper_writer, " class=\"arrow-button fa fa-angle-right\"");

WriteLiteralTo(__razor_helper_writer, "></i>\r\n                            <span");

WriteLiteralTo(__razor_helper_writer, " class=\"description\"");

WriteLiteralTo(__razor_helper_writer, ">Next <span");

WriteLiteralTo(__razor_helper_writer, " class=\"hide-mob\"");

WriteLiteralTo(__razor_helper_writer, ">page</span></span>\r\n                            <span");

WriteLiteralTo(__razor_helper_writer, " class=\"counter\"");

WriteLiteralTo(__razor_helper_writer, ">");


#line 181 "..\..\Views\Search\Index.cshtml"
                    WriteTo(__razor_helper_writer, Model.Page);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, " of ");


#line 181 "..\..\Views\Search\Index.cshtml"
                                   WriteTo(__razor_helper_writer, Model.LastPage);


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "</span>\r\n                        </a>\r\n");


#line 183 "..\..\Views\Search\Index.cshtml"
                    }


#line default
#line hidden
WriteLiteralTo(__razor_helper_writer, "\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n");


#line 189 "..\..\Views\Search\Index.cshtml"


#line default
#line hidden
});

#line 189 "..\..\Views\Search\Index.cshtml"
}
#line default
#line hidden

        public _Views_Search_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Search\Index.cshtml"
  
    Layout = "~/Views/Shared/_PortalLayout.cshtml";
    ViewBag.currentSection = "search";
    ViewBag.currentPage = "DAS Support-Search";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<section");

WriteLiteral(" class=\"search no-search-term\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-full\"");

WriteLiteral(">\r\n\r\n\r\n");

            
            #line 15 "..\..\Views\Search\Index.cshtml"
            
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Search\Index.cshtml"
             using (Html.BeginForm("Index", "Search", FormMethod.Get, new { accept_charset = "utf-8", @class = "search-header search-header-2", role = "search" }))
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"searchfield form-group\"");

WriteLiteral(">\r\n                    <fieldset");

WriteLiteral(" class=\"search-input\"");

WriteLiteral(">\r\n                        <h1");

WriteLiteral(" class=\"heading-large\"");

WriteLiteral(">Search</h1>\r\n");

WriteLiteral("                        ");

            
            #line 20 "..\..\Views\Search\Index.cshtml"
                   Write(Html.TextBoxFor(m => m.SearchTerm, string.Empty, new { id = "search-main", type = "search", @class = "form-control", placeholder = "Enter a name or email address", required = "required", maxlength = "100" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("                        ");

            
            #line 22 "..\..\Views\Search\Index.cshtml"
                   Write(Html.HiddenFor(m => m.Page));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </fieldset>\r\n\r\n                    <fieldset");

WriteLiteral(" class=\"search-submit\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"button\"");

WriteLiteral(">Search</button>\r\n                    </fieldset>\r\n                </div>\r\n");

            
            #line 29 "..\..\Views\Search\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <fieldset");

WriteLiteral(" class=\"inline\"");

WriteLiteral(">\r\n\r\n                        <div");

WriteLiteral(" class=\"multiple-choice\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 34 "..\..\Views\Search\Index.cshtml"
                       Write(Html.RadioButtonFor(m => m.SearchType, SearchCategory.User, new { id = "UserSearchType", @checked = "" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <label");

WriteLiteral(" for=\"UserSearchType\"");

WriteLiteral(">Users</label>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"multiple-choice\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 38 "..\..\Views\Search\Index.cshtml"
                       Write(Html.RadioButtonFor(m => m.SearchType, SearchCategory.Account, new { id = "AccountSearchType" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <label");

WriteLiteral(" for=\"AccountSearchType\"");

WriteLiteral(">Accounts</label>\r\n                        </div>\r\n\r\n                    </fields" +
"et>\r\n                </div>\r\n");

            
            #line 44 "..\..\Views\Search\Index.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"column-full\"");

WriteLiteral(">\r\n\r\n");

            
            #line 52 "..\..\Views\Search\Index.cshtml"
            
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\Search\Index.cshtml"
             if (Model.AccountSearchResults != null && Model.SearchType == SearchCategory.Account)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n                        <h2");

WriteLiteral(" class=\"heading-medium heading-medium__no-top-margin\"");

WriteLiteral(">Results</h2>\r\n                        <p>  ");

            
            #line 57 "..\..\Views\Search\Index.cshtml"
                        Write(Model.TotalAccountSearchItems);

            
            #line default
            #line hidden
WriteLiteral(" accounts found</p>\r\n                    </div>\r\n                </div>\r\n");

            
            #line 60 "..\..\Views\Search\Index.cshtml"


                if (Model.AccountSearchResults.Any())
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"column-two-thirds\"");

WriteLiteral(">\r\n                            <table");

WriteLiteral(" class=\"responsive\"");

WriteLiteral(">\r\n                                <thead>\r\n                                    <" +
"tr>\r\n                                        <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Account</th>\r\n                                        <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Account ID</th>\r\n                                        <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral("></th>\r\n                                    </tr>\r\n                              " +
"  </thead>\r\n                                <tbody>\r\n");

            
            #line 75 "..\..\Views\Search\Index.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Search\Index.cshtml"
                                     foreach (var account in Model.AccountSearchResults)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <tr>\r\n                                   " +
"         <td");

WriteLiteral(" data-label=\"Account\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 79 "..\..\Views\Search\Index.cshtml"
                                           Write(account.Account);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" data-label=\"Account ID\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 82 "..\..\Views\Search\Index.cshtml"
                                           Write(account.AccountID);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" data-label=\"\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 85 "..\..\Views\Search\Index.cshtml"
                                           Write(Html.ActionLink("view", "Index", "Resource", new { key = "account", id = account.AccountID }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"            </tr>\r\n");

            
            #line 88 "..\..\Views\Search\Index.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </tbody>\r\n                            </table>\r\n " +
"                       </div>\r\n                    </div>\r\n");

            
            #line 93 "..\..\Views\Search\Index.cshtml"

                    
            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\Search\Index.cshtml"
               Write(Pager());

            
            #line default
            #line hidden
            
            #line 94 "..\..\Views\Search\Index.cshtml"
                            
                }


            }
            else if (Model.UserSearchResults != null && Model.SearchType == SearchCategory.User)
            {




            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"column-full\"");

WriteLiteral(">\r\n                        <h2");

WriteLiteral(" class=\"heading-medium heading-medium__no-top-margin\"");

WriteLiteral(">Results</h2>\r\n                        <p>  ");

            
            #line 107 "..\..\Views\Search\Index.cshtml"
                        Write(Model.TotalUserSearchItems);

            
            #line default
            #line hidden
WriteLiteral(" users found</p>\r\n                    </div>\r\n                </div>\r\n");

            
            #line 110 "..\..\Views\Search\Index.cshtml"

                if (Model.UserSearchResults.Any())
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"grid-row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"column-full\"");

WriteLiteral(">\r\n                            <table");

WriteLiteral(" class=\"responsive\"");

WriteLiteral(">\r\n                                <thead>\r\n                                    <" +
"tr>\r\n                                        <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Name</th>\r\n                                        <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Email</th>\r\n                                        <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Status</th>\r\n                                        <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral("></th>\r\n                                    </tr>\r\n                              " +
"  </thead>\r\n                                <tbody>\r\n");

            
            #line 125 "..\..\Views\Search\Index.cshtml"
                                    
            
            #line default
            #line hidden
            
            #line 125 "..\..\Views\Search\Index.cshtml"
                                     foreach (var user in Model.UserSearchResults)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <tr>\r\n                                   " +
"         <td");

WriteLiteral(" data-label=\"Name\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 129 "..\..\Views\Search\Index.cshtml"
                                           Write(user.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" data-label=\"Email\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 132 "..\..\Views\Search\Index.cshtml"
                                           Write(user.Email);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" data-label=\"Status\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 135 "..\..\Views\Search\Index.cshtml"
                                           Write(user.Status);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"                <td");

WriteLiteral(" data-label=\"\"");

WriteLiteral(">\r\n");

WriteLiteral("                                                ");

            
            #line 138 "..\..\Views\Search\Index.cshtml"
                                           Write(Html.ActionLink("view", "Index", "Resource", new { key = "user", id = user.Id }, null));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                            </td>\r\n                            " +
"            </tr>\r\n");

            
            #line 141 "..\..\Views\Search\Index.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </tbody>\r\n                            </table>\r\n " +
"                       </div>\r\n                    </div>\r\n");

            
            #line 146 "..\..\Views\Search\Index.cshtml"

                    
            
            #line default
            #line hidden
            
            #line 147 "..\..\Views\Search\Index.cshtml"
               Write(Pager());

            
            #line default
            #line hidden
            
            #line 147 "..\..\Views\Search\Index.cshtml"
                            

                }
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n");

WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
