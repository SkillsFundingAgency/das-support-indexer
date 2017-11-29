﻿using System;
using System.Linq;
using System.Web.WebPages;
using HMRC.ESFA.Levy.Api.Types;
using SFA.DAS.Support.Portal.ApplicationServices.Responses;
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
#line 2 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
#line default
    #line hidden
    
    #line 3 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
#line default
    #line hidden
#line 4 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
#line default
    #line hidden

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [PageVirtualPath("~/Views/Account/PayeSchemeLevySubmissions.cshtml")]
    public partial class _Views_Account_PayeSchemeLevySubmissions_cshtml : System.Web.Mvc.WebViewPage<PayeSchemeLevySubmissionViewModel>
    {
        public _Views_Account_PayeSchemeLevySubmissions_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
  
    ViewBag.modelTitle = Model.Account?.DasAccountName;
    ViewBag.accountId = Model.Account?.HashedAccountId;
    ViewBag.dateRegistered = Model.Account.DateRegistered;
    ViewBag.currentSection = "account";
    ViewBag.currentPage = NavPages.PayeSchemeDetails;
    ViewBag.payeSchemes = Model.Account?.PayeSchemes;
    ViewBag.payePosition = Model.PayePosition;

    var selectedScheme = Model.Account.PayeSchemes?.ToList()[int.Parse(Model.PayePosition ?? "0")];

    var addedDate = selectedScheme == null || selectedScheme.AddedDate == DateTime.MinValue ? string.Empty :
        AccountHelper.ConvertDateTimeToDdmmyyyyFormat(selectedScheme.AddedDate);

    var reference = selectedScheme?.Ref;
    var name = selectedScheme?.Name;

            
            #line default
            #line hidden
WriteLiteral("    \r\n\r\n<h1");

WriteLiteral(" class=\"heading-xlarge\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                      Write(reference);

            
            #line default
            #line hidden
WriteLiteral(" Levy declarations</h1>\r\n<h4");

WriteLiteral(" class=\"paye-scheme-name\"");

WriteLiteral(">");

            
            #line 25 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                        Write(name);

            
            #line default
            #line hidden
WriteLiteral("</h4>\r\n");

            
            #line 26 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
 if (!string.IsNullOrEmpty(addedDate))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"paye-scheme-added-date\"");

WriteLiteral(">PAYE scheme added ");

            
            #line 28 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                                                     Write(addedDate);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 29 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<br/>\r\n");

            
            #line 31 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
 if (Model.Status == AccountLevySubmissionsResponseCodes.Success)
{
    if (Model.LevyDeclarations != null && Model.LevyDeclarations.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("        <table");

WriteLiteral(" id=\"submission-details\"");

WriteLiteral(">\r\n            <tr>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Submission date</th>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Payroll date</th>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Id</th>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Description</th>\r\n                <th");

WriteLiteral(" scope=\"col\"");

WriteLiteral(">Levy YTD</th>\r\n            </tr>\r\n\r\n");

            
            #line 44 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
            
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
             foreach (var levySubmission in Model.LevyDeclarations)
            {
                var declarationEmphasis = "unprocessed-submission";

                if (levySubmission.LevyDeclarationSubmissionStatus == LevyDeclarationSubmissionStatus.LateSubmission)
                {
                    declarationEmphasis = "late";
                }
                if (levySubmission.LevyDeclarationSubmissionStatus == LevyDeclarationSubmissionStatus.LatestSubmission)
                {
                    declarationEmphasis = "strong";
                }


            
            #line default
            #line hidden
WriteLiteral("                <tr >\r\n                    <td");

WriteAttribute("class", Tuple.Create(" class=\"", 2291), Tuple.Create("\"", 2319)
            
            #line 58 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
, Tuple.Create(Tuple.Create("", 2299), Tuple.Create<System.Object, System.Int32>(declarationEmphasis
            
            #line default
            #line hidden
, 2299), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 59 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                   Write(AccountHelper.GetSubmissionDate(levySubmission.SubmissionTime));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td");

WriteAttribute("class", Tuple.Create(" class=\"", 2462), Tuple.Create("\"", 2490)
            
            #line 61 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
, Tuple.Create(Tuple.Create("", 2470), Tuple.Create<System.Object, System.Int32>(declarationEmphasis
            
            #line default
            #line hidden
, 2470), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 62 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                   Write(AccountHelper.GetPayrollDate(levySubmission.PayrollPeriod));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td");

WriteAttribute("class", Tuple.Create(" class=\"", 2629), Tuple.Create("\"", 2657)
            
            #line 64 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
, Tuple.Create(Tuple.Create("", 2637), Tuple.Create<System.Object, System.Int32>(declarationEmphasis
            
            #line default
            #line hidden
, 2637), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 65 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                   Write(levySubmission.Id);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td aria-activedescendant");

WriteAttribute("class", Tuple.Create(" class=\"", 2777), Tuple.Create("\"", 2805)
            
            #line 67 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
, Tuple.Create(Tuple.Create("", 2785), Tuple.Create<System.Object, System.Int32>(declarationEmphasis
            
            #line default
            #line hidden
, 2785), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 68 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                   Write(AccountHelper.GetLevyDeclarationDescription(levySubmission));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td");

WriteAttribute("class", Tuple.Create(" class=\"", 2945), Tuple.Create("\"", 2973)
            
            #line 70 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
, Tuple.Create(Tuple.Create("", 2953), Tuple.Create<System.Object, System.Int32>(declarationEmphasis
            
            #line default
            #line hidden
, 2953), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 71 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
                   Write(AccountHelper.GetYearToDateAmount(levySubmission));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");

            
            #line 74 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n");

            
            #line 76 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" id=\"no-declarations-found\"");

WriteLiteral(">No declarations found for this PAYE scheme</p>\r\n");

            
            #line 80 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
    }
}
else if(Model.Status == AccountLevySubmissionsResponseCodes.AccountNotFound)
{

            
            #line default
            #line hidden
WriteLiteral("    <p");

WriteLiteral(" id=\"no-account-found\"");

WriteLiteral(">Couldn\'t find the account</p>\r\n");

            
            #line 85 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
}
else if (Model.Status == AccountLevySubmissionsResponseCodes.DeclarationsNotFound)
{

            
            #line default
            #line hidden
WriteLiteral("    <p");

WriteLiteral(" id=\"status-no-declarations-found\"");

WriteLiteral(">No declarations found for this PAYE scheme</p>\r\n");

            
            #line 89 "..\..\Views\Account\PayeSchemeLevySubmissions.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591