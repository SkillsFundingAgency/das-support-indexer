﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SFA.DAS.Support.Shared.SearchIndexModel
{
    [ExcludeFromCodeCoverage]
    public class AccountSearchModel : BaseSearchModel
    {
        public string Account { get; set; }
        public string AccountID { get; set; }
        public string PublicAccountID { get; set; }
        public List<string> PayeSchemeIds { get; set; }
        public string AccountSearchKeyWord => Account.ToLower();
        public string AccountIDSearchKeyWord => AccountID.ToLower();
        public string PublicAccountIDSearchKeyWord => PublicAccountID.ToLower();

        public IEnumerable<string> PayeSchemeIdSearchKeyWords
        {
            get { return PayeSchemeIds?.Select(o => o.ToLower()).ToList(); }
        }
    }
}