﻿using System;
using System.Collections.Generic;

namespace SFA.DAS.Support.Common.Infrastucture.Indexer
{
    public interface IIndexProvider
    {
        void CreateIndex<T>(string name) where T : class;

        void DeleteIndex(string name);

        void DeleteIndexes(Func<string, bool> indexNameMatch);

        void IndexDocuments<T>(string name, IEnumerable<T> documents) where T : class;

        bool IndexExists(string indexName);

         void CreateIndexAlias(string newIndexName, string aliasName);
    }
}