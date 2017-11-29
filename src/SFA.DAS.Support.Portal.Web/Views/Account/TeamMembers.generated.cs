﻿using System.Linq;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using SFA.DAS.Support.Portal.Web.Helpers;
using SFA.DAS.Support.Portal.Web.Models;
using SFA.DAS.Support.Portal.Web.ViewModels;

#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFA.DAS.Support.Portal.Web.Views.Account
{
#line 1 "..\..\Views\Account\TeamMembers.cshtml"
#line default
    #line hidden

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [PageVirtualPath("~/Views/Account/TeamMembers.cshtml")]
    public partial class _Views_Account_TeamMembers_cshtml : System.Web.Mvc.WebViewPage<AccountDetailViewModel>
    {
        public _Views_Account_TeamMembers_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Account\TeamMembers.cshtml"
  
    ViewBag.modelTitle = Model.Account.DasAccountName;
    ViewBag.accountId = Model.Account.HashedAccountId;
    ViewBag.dateRegistered = Model.Account.DateRegistered;
    ViewBag.currentSection = "account";
    ViewBag.currentPage = NavPages.TeamMembers;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 11 "..\..\Views\Account\TeamMembers.cshtml"
 if (Model.Account != null)
{

            
            #line default
            #line hidden
WriteLiteral("    <h1>\r\n        Team members\r\n    </h1>\r\n");

            
            #line 16 "..\..\Views\Account\TeamMembers.cshtml"
    if (Model.Account.TeamMembers.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("        <table>\r\n            <tr>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Name</th>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Email</th>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Role</th>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Status</th>\r\n            </tr>\r\n");

            
            #line 25 "..\..\Views\Account\TeamMembers.cshtml"
            
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Account\TeamMembers.cshtml"
             foreach (var item in Model.Account.TeamMembers)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td");

WriteLiteral(" id=\"teamMemberName\"");

WriteLiteral(">\r\n");

            
            #line 29 "..\..\Views\Account\TeamMembers.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Account\TeamMembers.cshtml"
                         if (!string.IsNullOrEmpty(item.UserRef))
                        {
                            
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Account\TeamMembers.cshtml"
                       Write(Html.ActionLink(item.Name, "Detail", "Search", new { id = item.UserRef }, null));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Account\TeamMembers.cshtml"
                                                                                                            
                        }
                        else
                        {
                            
            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Account\TeamMembers.cshtml"
                       Write(item.Name);

            
            #line default
            #line hidden
            
            #line 35 "..\..\Views\Account\TeamMembers.cshtml"
                                      
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n                    <td");

WriteLiteral(" id=\"teamMemberEmail\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 39 "..\..\Views\Account\TeamMembers.cshtml"
                   Write(item.Email);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td");

WriteLiteral(" id=\"teamMemberRole\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 42 "..\..\Views\Account\TeamMembers.cshtml"
                   Write(item.Role);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td");

WriteLiteral(" id=\"teamMemberStatus\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 45 "..\..\Views\Account\TeamMembers.cshtml"
                   Write(AccountHelper.GetTeamMemberStatus(item.Status));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");

            
            #line 48 "..\..\Views\Account\TeamMembers.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n");

            
            #line 50 "..\..\Views\Account\TeamMembers.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <p>No team members availables</p>\r\n");

            
            #line 54 "..\..\Views\Account\TeamMembers.cshtml"
    }
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <p>Account not found</p>\r\n");

            
            #line 59 "..\..\Views\Account\TeamMembers.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591