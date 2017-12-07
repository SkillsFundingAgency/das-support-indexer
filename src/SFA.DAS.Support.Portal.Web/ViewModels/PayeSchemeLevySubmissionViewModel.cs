﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HMRC.ESFA.Levy.Api.Types;
using SFA.DAS.Support.Portal.ApplicationServices.Responses;
using SFA.DAS.Support.Portal.Core.Domain.Model;

namespace SFA.DAS.Support.Portal.Web.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class PayeSchemeLevySubmissionViewModel
    {
        public Account Account { get; set; }
        public List<Declaration> LevyDeclarations { get; set; }

        public string PayePosition { get; set; }
        public AccountLevySubmissionsResponseCodes Status { get; set; }
    }
}